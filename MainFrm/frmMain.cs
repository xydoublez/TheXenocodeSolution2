namespace MainFrm
{
    using About;
    using PESECTION;
    using Zip;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;

    public sealed class frmMain : Form
    {
        private Button button1;
        private Button button2;
        private Button button3;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private IContainer icontainer_0;
        private ListBox listBox1;
        private OpenFileDialog openFileDialog_0;
        private TextBox textBox1;

        public frmMain()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = false;
            this.listBox1.Items.Clear();
            this.PrintLog("[*] Starting");
            this.PrintLog("[*] Reading file");
            try
            {
                BinaryReader reader = new BinaryReader(File.Open(this.textBox1.Text, FileMode.Open, FileAccess.Read, FileShare.None));
                Section[] pesection = new PeHdr(reader).method_3();
                this.PrintLog("[*] Searching for Xenocode section");
//                 byte[] buffer2 = Class0.smethod_0(Application.ExecutablePath);
//                 for (int i = 0; i < 7; i++)
//                 {
//                     if (buffer2[i] != (Class0.byte_0[i] ^ 0x86))
//                     {
//                         Application.Exit();
//                     }
//                 }
                int index = 0;
                while (index < pesection.Length)
                {
                    if ((pesection[index].method_3() == ".text") && (pesection[index + 2].method_3() == ".xcpad"))
                    {
                        goto Label_0111;
                    }
                    if (pesection[index].method_3() == ".datacxc")
                    {
                        goto Label_011F;
                    }
                    if (index == (pesection.Length - 1))
                    {
                        this.PrintLog("[*] Xenocode section not found!");
                        this.PrintLog("[*] Unprotected file or new version!");
                    }
                    index++;
                }
                goto Label_01A6;
            Label_0111:
                this.DoUnpack4(index, reader);
                goto Label_01A6;
            Label_011F:
                this.PrintLog("[*] Found Xenocode section");
                byte[] buffer = new byte[pesection[index].method_5()];
                reader.BaseStream.Position = pesection[index].method_6();
                reader.Read(buffer, 0, buffer.Length);
                if (((index == 0) && (buffer[4] == 120)) && (buffer[5] == 0x9c))
                {
                    this.DoUnpack1(pesection, index, buffer);
                }
                else if (BitConverter.ToInt32(buffer, 0) == pesection[index].method_6())
                {
                    this.DoUnpack2(pesection, index, buffer);
                }
                else
                {
                    this.DoUnpack2(pesection, index, buffer);
                }
            Label_01A6:
                reader.Close();
            }
            catch
            {
                this.PrintLog("");
                this.PrintLog("[*] Error while processing file :(");
                this.PrintLog("[*] This file can not be unpacked :(");
            }
            this.button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ClearLog();
            this.button1.Enabled = false;
            this.textBox1.Text = string.Empty;
            this.openFileDialog_0.FileName = "";
            this.openFileDialog_0.ShowDialog();
//             byte[] buffer = Class0.smethod_0(Application.ExecutablePath);
//             for (int i = 0; i < 7; i++)
//             {
//                 if (buffer[i] != (Class0.byte_0[i] ^ 0x86))
//                 {
//                     Application.Exit();
//                 }
//             }
            if (this.openFileDialog_0.FileName.Length > 1)
            {
                this.textBox1.Text = this.openFileDialog_0.FileName;
                this.button1.Enabled = true;
                this.listBox1.Items.Clear();
                this.PrintLog("[*] Ready");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new frmAbout().ShowDialog();
        }

        protected override void Dispose(bool bool_0)
        {
            if (bool_0 && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(bool_0);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
//             byte[] buffer = Class0.smethod_0(Application.ExecutablePath);
//             for (int i = 0; i < 7; i++)
//             {
//                 if (buffer[i] != (Class0.byte_0[i] ^ 0x86))
//                 {
//                     Application.Exit();
//                 }
//             }
            this.Text = string.Format("{0} {1} - {2}", "The Xenocode Solution", "v2.0", " LibX//RETeam");
            this.ClearLog();
        }

        private void InitializeComponent()
        {
            this.icontainer_0 = null;
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.openFileDialog_0 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(136, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "UNPACK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(16, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(352, 20);
            this.textBox1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 56);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File To Unpack";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(368, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 20);
            this.button2.TabIndex = 3;
            this.button2.Text = "....";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Location = new System.Drawing.Point(8, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 184);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(8, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(400, 160);
            this.listBox1.TabIndex = 0;
            // 
            // openFileDialog_0
            // 
            this.openFileDialog_0.Filter = "EXE|*.exe|DLL|*.dll";
            this.openFileDialog_0.SupportMultiDottedExtensions = true;
            this.openFileDialog_0.Title = "Open File To Unpack";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(400, 264);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 24);
            this.button3.TabIndex = 4;
            this.button3.Text = "?";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 295);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void PrintLog(string string_0)
        {
            this.listBox1.Items.Add(string_0);
            int num = this.listBox1.Height / this.listBox1.ItemHeight;
            this.listBox1.TopIndex = this.listBox1.Items.Count - num;
        }

        private void ClearLog()
        {
            this.listBox1.Items.Clear();
            this.PrintLog("[*] Open a file to unpack");
        }

        private void DoUnpack1(Section[] class3_0, int int_0, byte[] byte_0)
        {
            byte[] sourceArray = byte_0;
            this.PrintLog("[*] Detected Xenocode 2005 output compression");
            this.PrintLog("[*] Doing single file extraction");
            Array.Copy(sourceArray, 4, sourceArray, 0, sourceArray.Length - 4);
            Array.Resize<byte>(ref sourceArray, sourceArray.Length - 4);
            GZipStream stream = new GZipStream(new MemoryStream(sourceArray));
            try
            {
                this.PrintLog(string.Format("[*][{1}/{2}] Unpacking: {0}", Path.GetFileName(this.textBox1.Text), 1, 1));
                Application.DoEvents();
                byte[] buffer = new byte[class3_0[int_0].method_4() * 0x10];
                stream.Read(buffer, 0, (int) (class3_0[int_0].method_4() * 0x10));
                File.WriteAllBytes(Path.GetFileNameWithoutExtension(this.textBox1.Text) + @"_Unpacked\" + Path.GetFileName(this.textBox1.Text), buffer);
                this.PrintLog("");
                this.PrintLog("[*] File succesfully unpacked!");
                this.PrintLog("");
                this.PrintLog(string.Format("[*] File succesfully unpacked to folder: {0}", Path.GetFileNameWithoutExtension(this.textBox1.Text) + "_Unpacked"));
            }
            catch
            {
                this.PrintLog("");
                this.PrintLog("[*] output extraction failed!");
            }
            stream.Close();
        }

        private void DoUnpack2(Section[] class3_0, int int_0, byte[] byte_0)
        {
            byte[] sourceArray = byte_0;
            this.PrintLog("[*] Detected PostBuild output compression");
            this.PrintLog("[*] Doing single file extraction");
            Array.Copy(sourceArray, 4, sourceArray, 0, sourceArray.Length - 4);
            Array.Resize<byte>(ref sourceArray, sourceArray.Length - 4);
            GZipStream stream = new GZipStream(new MemoryStream(sourceArray));
            try
            {
                this.PrintLog(string.Format("[*][{1}/{2}] Unpacking: {0}", Path.GetFileName(this.textBox1.Text), 1, 1));
                Application.DoEvents();
                byte[] buffer = new byte[class3_0[int_0].method_6()];
                stream.Read(buffer, 0, (int) class3_0[int_0].method_6());
                File.WriteAllBytes(Path.GetFileNameWithoutExtension(this.textBox1.Text) + @"_Unpacked\" + Path.GetFileName(this.textBox1.Text), buffer);
                this.PrintLog("");
                this.PrintLog("[*] File succesfully unpacked!");
                this.PrintLog("");
                this.PrintLog(string.Format("[*] File succesfully unpacked to folder: {0}", Path.GetFileNameWithoutExtension(this.textBox1.Text) + "_Unpacked"));
            }
            catch
            {
                this.PrintLog("");
                this.PrintLog("[*] output extraction failed!");
            }
            stream.Close();
        }

        private void DoUnpack3(Section[] class3_0, int int_0, byte[] byte_0)
        {
            bool flag = false;
            string str = Directory.CreateDirectory(Path.GetDirectoryName(this.textBox1.Text) + @"\" + Path.GetFileNameWithoutExtension(this.textBox1.Text) + "_Unpacked").FullName + @"\";
            byte[] buffer = byte_0;
            XmlDocument document = new XmlDocument();
            this.PrintLog("[*] Decrypting config");
            byte[] destinationArray = new byte[BitConverter.ToInt32(buffer, 4) ^ 0x47446f67];
            Array.Copy(buffer, 8, destinationArray, 0, destinationArray.Length);
            FileStream stream2 = new FileStream(new MemoryStream(destinationArray), BitConverter.ToInt32(buffer, 0) ^ 0x47446f67);
            stream2.Read(destinationArray, 0, destinationArray.Length);
            GZipStream stream = new GZipStream(new MemoryStream(destinationArray));
            this.PrintLog("[*] Decompressing config");
            byte[] array = new byte[0];
            while (stream.vmethod_0() == 1)
            {
                Array.Resize<byte>(ref array, array.Length + 1);
                stream.Read(array, array.Length - 1, 1);
            }
            int index = 0;
            while (array[index] != 60)
            {
                index++;
            }
            Array.Copy(array, index, array, 0, array.Length - index);
            this.PrintLog("[*] Parsing config");
            document.LoadXml(Encoding.UTF8.GetString(array));
            byte[] buffer3 = new byte[(class3_0[int_0].method_5() - 8) - (BitConverter.ToInt32(buffer, 4) ^ 0x47446f67)];
            Array.Copy(buffer, (BitConverter.ToInt32(buffer, 4) ^ 0x47446f67) + 8, buffer3, 0, buffer3.Length);
            XmlNodeList list = document.SelectNodes("//File");
            if (list.Count == 0)
            {
                list = document.SelectNodes("//file");
                this.PrintLog("[*] Detected Xenocode PostBuild 2006");
                flag = true;
            }
            else if (class3_0[int_0 + 4].method_3() == ".textxc2")
            {
                this.PrintLog("[*] Detected Xenocode Virtual Appliance Studio <= v5.1.x");
            }
            else
            {
                this.PrintLog("[*] Detected Xenocode PostBuild 2007");
            }
            this.PrintLog(string.Format("[*] Found {0} file in the VM/x86/VA package", list.Count));
            int num2 = 0;
            while (true)
            {
                string fileName;
                int num3;
                int num4;
                int num5;
                int num6;
                if (num2 >= list.Count)
                {
                    break;
                }
                if (flag)
                {
                    fileName = list[num2].Attributes["name"].Value;
                }
                else
                {
                    fileName = list[num2].Attributes["Name"].Value;
                }
                if ((fileName == "%APPNAME%") || (fileName == "theapp.exe"))
                {
                    fileName = Path.GetFileName(this.textBox1.Text);
                }
                if (flag)
                {
                    num3 = int.Parse(list[num2].Attributes["seed"].Value, NumberStyles.HexNumber);
                    num4 = int.Parse(list[num2].Attributes["ostart"].Value, NumberStyles.HexNumber);
                    num5 = int.Parse(list[num2].Attributes["olength"].Value, NumberStyles.HexNumber);
                    num6 = int.Parse(list[num2].Attributes["fullsize"].Value, NumberStyles.HexNumber);
                }
                else
                {
                    num3 = int.Parse(list[num2].Attributes["Seed"].Value, NumberStyles.HexNumber);
                    num4 = int.Parse(list[num2].Attributes["Start"].Value, NumberStyles.HexNumber);
                    num5 = int.Parse(list[num2].Attributes["Length"].Value, NumberStyles.HexNumber);
                    num6 = int.Parse(list[num2].Attributes["Fullsize"].Value, NumberStyles.HexNumber);
                }
                try
                {
                    this.PrintLog(string.Format("[*][{1}/{2}] Unpacking: {0}", fileName, num2 + 1, list.Count));
                    Application.DoEvents();
                    byte[] buffer5 = new byte[num5];
                    Array.Copy(buffer3, num4, buffer5, 0, num5);
                    stream2 = new FileStream(new MemoryStream(buffer5), num3);
                    stream2.Read(buffer5, 0, buffer5.Length);
                    byte[] buffer6 = new byte[num6];
                    stream = new GZipStream(new MemoryStream(buffer5));
                    stream.Read(buffer6, 0, num6);
                    File.WriteAllBytes(str + fileName, buffer6);
                }
                catch
                {
                    this.PrintLog(string.Format("[*] Error while unpacking: {0}", fileName));
                }
                num2++;
            }
            this.PrintLog("");
            this.PrintLog("[*] All files succesfully unpacked!");
            this.PrintLog("");
            this.PrintLog(string.Format("[*] Files are unpacked to folder: {0}", Path.GetFileNameWithoutExtension(this.textBox1.Text) + "_Unpacked"));
            stream2.Close();
            stream.Close();
        }

        private void DoUnpack4(int int_0, BinaryReader binaryReader_0)
        {
            int num2;
            string str = Directory.CreateDirectory(Path.GetDirectoryName(this.textBox1.Text) + @"\" + Path.GetFileNameWithoutExtension(this.textBox1.Text) + "_Unpacked").FullName + @"\";
            this.PrintLog("[*] Detected Xenocode Virtual Appliance Studio >= v5.2.x");
            this.PrintLog("[*] Or PostBuild 2007 >= v5.2.x");
            binaryReader_0.BaseStream.Position = 0;
            Section[] pesection = new PeHdr(binaryReader_0).method_3();
            XmlDocument document = new XmlDocument();
            byte[] buffer = new byte[binaryReader_0.BaseStream.Length];
            binaryReader_0.BaseStream.Position = 0;
            binaryReader_0.Read(buffer, 0, buffer.Length);
            int startIndex = ((int)pesection[int_0].method_0()) + 0x10;
            int num3 = 0;
            for (int i = pesection.Length; i > 0; i--)
            {
                num2 = BitConverter.ToInt32(buffer, startIndex);
                if (num2 != 0)
                {
                    num3 = BitConverter.ToInt32(buffer, startIndex + 4) + num2;
                }
                startIndex += 40;
            }
            int num5 = num3;
            binaryReader_0.BaseStream.Position = num3;
            pesection = new PeHdr(binaryReader_0).method_3();
            startIndex = ((int)pesection[0].method_0()) + 0x10;
            num3 = 0;
            for (int j = pesection.Length; j > 0; j--)
            {
                num2 = BitConverter.ToInt32(buffer, startIndex);
                if (num2 != 0)
                {
                    num3 = BitConverter.ToInt32(buffer, startIndex + 4) + num2;
                    num3 += num5;
                }
                startIndex += 40;
            }
            binaryReader_0.BaseStream.Position = num3;
            buffer = new byte[binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position];
            binaryReader_0.Read(buffer, 0, buffer.Length);
            this.PrintLog("[*] Decrypting config");
            byte[] destinationArray = new byte[BitConverter.ToInt32(buffer, 4) ^ 0x47446f67];
            Array.Copy(buffer, 8, destinationArray, 0, destinationArray.Length);
            FileStream stream2 = new FileStream(new MemoryStream(destinationArray), BitConverter.ToInt32(buffer, 0) ^ 0x47446f67);
            stream2.Read(destinationArray, 0, destinationArray.Length);
            GZipStream stream = new GZipStream(new MemoryStream(destinationArray));
            this.PrintLog("[*] Decompressing config");
            byte[] array = new byte[0];
            while (stream.vmethod_0() == 1)
            {
                Array.Resize<byte>(ref array, array.Length + 1);
                stream.Read(array, array.Length - 1, 1);
            }
            int index = 0;
            while (array[index] != 60)
            {
                index++;
            }
            Array.Copy(array, index, array, 0, array.Length - index);
            this.PrintLog("[*] Parsing config");
            document.LoadXml(Encoding.UTF8.GetString(array));
            byte[] buffer3 = new byte[(buffer.Length - (BitConverter.ToInt32(buffer, 4) ^ 0x47446f67)) - 8];
            Array.Copy(buffer, (BitConverter.ToInt32(buffer, 4) ^ 0x47446f67) + 8, buffer3, 0, buffer3.Length);
            XmlNodeList list = document.SelectNodes("//File");
            this.PrintLog(string.Format("[*] Found {0} file in the VM/x86/VA package", list.Count));
            int num8 = 0;
            while (true)
            {
                if (num8 >= list.Count)
                {
                    break;
                }
                string fileName = list[num8].Attributes["Name"].Value;
                switch (fileName)
                {
                    case "%APPNAME%":
                    case "theapp.exe":
                        fileName = Path.GetFileName(this.textBox1.Text);
                        break;
                }
                int num9 = int.Parse(list[num8].Attributes["Seed"].Value, NumberStyles.HexNumber);
                int sourceIndex = int.Parse(list[num8].Attributes["Start"].Value, NumberStyles.HexNumber);
                int length = int.Parse(list[num8].Attributes["Length"].Value, NumberStyles.HexNumber);
                int count = int.Parse(list[num8].Attributes["Fullsize"].Value, NumberStyles.HexNumber);
                try
                {
                    this.PrintLog(string.Format("[*][{1}/{2}] Unpacking: {0}", fileName, num8 + 1, list.Count));
                    Application.DoEvents();
                    byte[] buffer5 = new byte[length];
                    Array.Copy(buffer3, sourceIndex, buffer5, 0, length);
                    stream2 = new FileStream(new MemoryStream(buffer5), num9);
                    stream2.Read(buffer5, 0, buffer5.Length);
                    byte[] buffer6 = new byte[count];
                    stream = new GZipStream(new MemoryStream(buffer5));
                    stream.Read(buffer6, 0, count);
                    File.WriteAllBytes(str + fileName, buffer6);
                }
                catch
                {
                    this.PrintLog(string.Format("[*] Error while unpacking: {0}", fileName));
                }
                num8++;
            }
            this.PrintLog("");
            this.PrintLog("[*] All files succesfully unpacked!");
            this.PrintLog("");
            this.PrintLog(string.Format("[*] Files are unpacked to folder: {0}", Path.GetFileNameWithoutExtension(this.textBox1.Text) + "_Unpacked"));
            stream2.Close();
            stream.Close();
        }
        private void DoUnpack5(int int_0, BinaryReader binaryReader_0)
        {
        }
    }
}

