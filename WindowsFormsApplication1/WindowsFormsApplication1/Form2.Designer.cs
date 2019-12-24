namespace WindowsFormsApplication1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.nx = new CS_ClassLibraryTester.NYX_Theme();
            this.Exit = new CS_ClassLibraryTester.BoosterButton();
            this.delphi = new System.Windows.Forms.PictureBox();
            this.chnn = new CS_ClassLibraryTester.BoosterButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.codedby = new System.Windows.Forms.Label();
            this.nx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delphi)).BeginInit();
            this.SuspendLayout();
            // 
            // nx
            // 
            this.nx.Animated = true;
            this.nx.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.nx.Colors = new CS_ClassLibraryTester.Bloom[0];
            this.nx.Controls.Add(this.Exit);
            this.nx.Controls.Add(this.delphi);
            this.nx.Controls.Add(this.chnn);
            this.nx.Controls.Add(this.label2);
            this.nx.Controls.Add(this.label1);
            this.nx.Controls.Add(this.codedby);
            this.nx.Customization = "";
            this.nx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nx.Font = new System.Drawing.Font("Verdana", 8F);
            this.nx.Image = null;
            this.nx.Location = new System.Drawing.Point(0, 0);
            this.nx.Movable = true;
            this.nx.Name = "nx";
            this.nx.NoRounding = false;
            this.nx.Sizable = false;
            this.nx.Size = new System.Drawing.Size(497, 468);
            this.nx.SmartBounds = true;
            this.nx.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.nx.TabIndex = 0;
            this.nx.Text = "About";
            this.nx.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.nx.Transparent = false;
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.Colors = new CS_ClassLibraryTester.Bloom[0];
            this.Exit.Customization = "";
            this.Exit.Font = new System.Drawing.Font("Verdana", 8F);
            this.Exit.Image = null;
            this.Exit.Location = new System.Drawing.Point(422, 0);
            this.Exit.Name = "Exit";
            this.Exit.NoRounding = false;
            this.Exit.Size = new System.Drawing.Size(72, 23);
            this.Exit.TabIndex = 28;
            this.Exit.Text = "X";
            this.Exit.Transparent = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // delphi
            // 
            this.delphi.BackColor = System.Drawing.Color.Transparent;
            this.delphi.Image = ((System.Drawing.Image)(resources.GetObject("delphi.Image")));
            this.delphi.Location = new System.Drawing.Point(176, 272);
            this.delphi.Name = "delphi";
            this.delphi.Size = new System.Drawing.Size(150, 150);
            this.delphi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.delphi.TabIndex = 27;
            this.delphi.TabStop = false;
            // 
            // chnn
            // 
            this.chnn.BackColor = System.Drawing.Color.Transparent;
            this.chnn.Colors = new CS_ClassLibraryTester.Bloom[0];
            this.chnn.Customization = "";
            this.chnn.Font = new System.Drawing.Font("Verdana", 8F);
            this.chnn.Image = null;
            this.chnn.Location = new System.Drawing.Point(144, 145);
            this.chnn.Name = "chnn";
            this.chnn.NoRounding = false;
            this.chnn.Size = new System.Drawing.Size(215, 35);
            this.chnn.TabIndex = 26;
            this.chnn.Text = "My YouTube Channel";
            this.chnn.Transparent = true;
            this.chnn.Click += new System.EventHandler(this.chnn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(148, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Section 13 Group B";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Viner Hand ITC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(157, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 39);
            this.label1.TabIndex = 22;
            this.label1.Text = "\" W ! Z A R D \"";
            // 
            // codedby
            // 
            this.codedby.AutoSize = true;
            this.codedby.BackColor = System.Drawing.Color.Transparent;
            this.codedby.Font = new System.Drawing.Font("MrRobot", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codedby.ForeColor = System.Drawing.Color.Red;
            this.codedby.Location = new System.Drawing.Point(34, 47);
            this.codedby.Name = "codedby";
            this.codedby.Size = new System.Drawing.Size(434, 24);
            this.codedby.TabIndex = 21;
            this.codedby.Text = "Coded By : Mohammed AL Sayed ";
            this.codedby.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 468);
            this.Controls.Add(this.nx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.nx.ResumeLayout(false);
            this.nx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delphi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CS_ClassLibraryTester.NYX_Theme nx;
        private System.Windows.Forms.PictureBox delphi;
        private CS_ClassLibraryTester.BoosterButton chnn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label codedby;
        private CS_ClassLibraryTester.BoosterButton Exit;
    }
}