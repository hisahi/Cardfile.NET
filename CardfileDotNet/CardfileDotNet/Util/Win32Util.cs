using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CardfileDotNet.Util
{
    public static class Win32Util
    {
        public static object GetFileDescription(string ext)
        {
            Win32Native.SHFILEINFO shFileInfo;
            if (IntPtr.Zero != Win32Native.SHGetFileInfo(ext,
                                Win32Native.FILE_ATTRIBUTE_NORMAL,
                                out shFileInfo,
                                (uint)Marshal.SizeOf(typeof(Win32Native.SHFILEINFO)),
                                Win32Native.SHGFI_USEFILEATTRIBUTES | Win32Native.SHGFI_TYPENAME))
            {
                return shFileInfo.szTypeName;
            }
            return null;
        }

        public static Icon GetIconForExtension(string ext)
        {
            Win32Native.SHFILEINFO shFileInfo;
            if (IntPtr.Zero != Win32Native.SHGetFileInfo(ext,
                                Win32Native.FILE_ATTRIBUTE_NORMAL,
                                out shFileInfo,
                                (uint)Marshal.SizeOf(typeof(Win32Native.SHFILEINFO)),
                                Win32Native.SHGFI_ICON | Win32Native.SHGFI_USEFILEATTRIBUTES | (Environment.OSVersion.Version.Major >= 6 ? Win32Native.SHIL_JUMBO : Win32Native.SHGFI_LARGEICON)))
            {
                Icon icon = Icon.FromHandle(shFileInfo.hIcon).Clone() as Icon;
                Win32Native.DestroyIcon(shFileInfo.hIcon);
                return icon;
            }
            return SystemIcons.Application;
        }
    }

    static class Win32Native
    {
        internal const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
        internal const uint SHGFI_TYPENAME = 0x000000400;
        internal const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;
        internal const uint SHGFI_ICON = 0x00000100;
        internal const uint SHGFI_LARGEICON = 0x00000000;
        internal const uint SHIL_JUMBO = 0x00000004;

        [DllImport("shell32")]
        internal static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, out SHFILEINFO psfi, uint cbFileInfo, uint flags);

        [StructLayout(LayoutKind.Sequential)]
        internal struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        [DllImport("user32")]
        public static extern bool DestroyIcon(IntPtr hIcon);
    }
}