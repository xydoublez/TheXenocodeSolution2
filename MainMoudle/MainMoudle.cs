namespace MainMoudle
{
    using MainFrm;
    using System;
    using System.Windows.Forms;

    internal static class MainMoudle
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}

