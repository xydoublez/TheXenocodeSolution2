namespace About
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    public sealed class frmAbout : Form
    {
        private Button button1;
        private IContainer icontainer_0;
        private Label label1;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private ListBox listBox1;

        public frmAbout()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        protected override void Dispose(bool bool_0)
        {
            if (bool_0 && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(bool_0);
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            this.label1.Text = string.Format("{0} {1}", "The Xenocode Solution", "v2.0");
            this.listBox1.Items.Add("");
            this.listBox1.Items.Add("Unpacker Features:");
            this.listBox1.Items.Add("[*] Unpack Xenocode 2005 output compression");
            this.listBox1.Items.Add("[*] Unpack Xenocode PostBuild 2006 output compression");
            this.listBox1.Items.Add("[*] Unpack Xenocode PostBuild 2006 Virtual Machine");
            this.listBox1.Items.Add("[*] Unpack Xenocode PostBuild 2006 x86 Compilation");
            this.listBox1.Items.Add("[*] Unpack Xenocode PostBuild <= v5.1.x 2007 output compression");
            this.listBox1.Items.Add("[*] Unpack Xenocode PostBuild <= v5.1.x 2007 Virtual Machine");
            this.listBox1.Items.Add("[*] Unpack Xenocode PostBuild <= v5.1.x 2007 x86 Compilation");
            this.listBox1.Items.Add("[*] Unpack Xenocode PostBuild >= v5.2.x 2007 Virtual Machine");
            this.listBox1.Items.Add("[*] Unpack Xenocode PostBuild >= v5.2.x 2007 x86 Compilation");
            this.listBox1.Items.Add("[*] Unpack Xenocode Virtual Appliance Studio <= v5.1.x packages");
            this.listBox1.Items.Add("[*] Unpack Xenocode Virtual Appliance Studio >= v5.2.x packages");
            this.listBox1.Items.Add("[*] Unpack Xenocode PostBuild 2010 Virtual Machine, use zip ,Not Done! ");
            this.listBox1.Items.Add("");
            this.listBox1.Items.Add("PuMO");
        }

        private void InitializeComponent()
        {
            this.icontainer_0 = null;
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(8, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(344, 212);
            this.listBox1.TabIndex = 1;
            this.listBox1.TabStop = false;
            this.listBox1.UseTabStops = false;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(16, 256);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(83, 13);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "oump@cosl.com.cn";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(224, 256);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(120, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.cosl.com.cn/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(152, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 16);
            this.button1.TabIndex = 5;
            this.button1.Text = "CLOSE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAbout
            // 
            this.ClientSize = new System.Drawing.Size(360, 284);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.cosl.com.cn", "");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:oump@cosl.com.cn", "");
        }
    }
}

