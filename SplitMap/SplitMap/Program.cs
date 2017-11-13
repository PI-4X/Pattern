using SplitMap.Animal.BridgeDraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitMap
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ManagerConsole managerConsole = new ManagerConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DialogResult dialogResult = MessageBox.Show("Form", "Console", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
                Application.Run(new Form1());
            else
            {
                ConsoleGameManager cgm = new ConsoleGameManager();
                managerConsole.ShowConsole();
               // Application.Run();
                cgm.Start();
            }
                
        }
    }
    public class ManagerConsole
    {
        [DllImport("kernel32.dll",
        EntryPoint = "GetStdHandle",
        SetLastError = true,
        CharSet = CharSet.Auto,
        CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll",
            EntryPoint = "AllocConsole",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;
        private const int STD_OUTPUT_HANDLE = -11;
        private const int MY_CODE_PAGE = 437;

        private IntPtr Handle;
        public ManagerConsole()
        {
            AllocConsole();
            Handle = GetConsoleWindow();
            HideConsole();
        }
        public void ShowConsole()
        {
            ShowWindow(Handle, SW_SHOW);
        }
        public void HideConsole()
        {
            ShowWindow(Handle, SW_HIDE);
        }
    }
}
