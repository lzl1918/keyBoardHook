using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace KeyboardHook
{
    public partial class Hk_Form : Form
    {
        private Hocy_Hook hook_Main = new Hocy_Hook();
        public Hk_Form()
        {
            InitializeComponent();
           
             this.hook_Main.OnMouseActivity += new MouseEventHandler(hook_MainMouseMove);
             this.hook_Main.OnKeyDown += new KeyEventHandler(hook_MainKeyDown);
             this.hook_Main.OnKeyPress += new KeyPressEventHandler(hook_MainKeyPress);
             this.hook_Main.OnKeyUp += new KeyEventHandler(hook_MainKeyUp);
        }

        private void Hk_Form_Load(object sender, EventArgs e)
        {
           
        }

        private void Hk_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
           this.hook_Main.UnInstallHook();
        }
        private void HookMain_OnKeyDown(object sender, KeyEventArgs e)
        {
           // MessageBox.Show("33");
            if (e.KeyCode == Keys.Escape && Control.ModifierKeys == Keys.Shift)
            {
                this.Close();
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            hook_Main.InstallHook("1");
        }

        private void stop_Click(object sender, EventArgs e)
        {
            this.hook_Main.UnInstallHook();
        }

        private void stopkeyboard_Click(object sender, EventArgs e)
        {
            hook_Main.InstallHook("2");
        }

        private void LogWrite(string txt)
        {

            this.resultinfo.AppendText(txt + Environment.NewLine);
            this.resultinfo.SelectionStart = this.resultinfo.Text.Length;
        }

        private void hook_MainKeyDown(object sender, KeyEventArgs e)
        {
            LogWrite("KeyDown 	- " + e.KeyData.ToString());
        }

        private void hook_MainKeyPress(object sender, KeyPressEventArgs e)
        {
            LogWrite("KeyPress 	- " + e.KeyChar);
        }

        private void hook_MainKeyUp(object sender, KeyEventArgs e)
        {
            LogWrite("KeyUp 		- " + e.KeyData.ToString());
        }

        private void hook_MainMouseMove(object sender, MouseEventArgs e)
        {
            labelMousePosition.Text = String.Format("x={0}  y={1} wheel={2}", e.X, e.Y, e.Delta);
            if (e.Clicks > 0) LogWrite("MouseButton 	- " + e.Button.ToString());
        }


    }
}