
namespace AKD_zadatak_Karlo
{
    partial class Form1
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
            this.textBoxIzvorni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonIzv = new System.Windows.Forms.Button();
            this.buttonOdr = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOdredisni = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonPokreni = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxIzvorni
            // 
            this.textBoxIzvorni.Location = new System.Drawing.Point(137, 23);
            this.textBoxIzvorni.Name = "textBoxIzvorni";
            this.textBoxIzvorni.Size = new System.Drawing.Size(299, 20);
            this.textBoxIzvorni.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mapa izvora:";
            // 
            // buttonIzv
            // 
            this.buttonIzv.Location = new System.Drawing.Point(456, 21);
            this.buttonIzv.Name = "buttonIzv";
            this.buttonIzv.Size = new System.Drawing.Size(75, 23);
            this.buttonIzv.TabIndex = 2;
            this.buttonIzv.Text = "Izvor";
            this.buttonIzv.UseVisualStyleBackColor = true;
            this.buttonIzv.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonOdr
            // 
            this.buttonOdr.Location = new System.Drawing.Point(456, 62);
            this.buttonOdr.Name = "buttonOdr";
            this.buttonOdr.Size = new System.Drawing.Size(75, 23);
            this.buttonOdr.TabIndex = 5;
            this.buttonOdr.Text = "Odredište";
            this.buttonOdr.UseVisualStyleBackColor = true;
            this.buttonOdr.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mapa odredišta:";
            // 
            // textBoxOdredisni
            // 
            this.textBoxOdredisni.Location = new System.Drawing.Point(137, 64);
            this.textBoxOdredisni.Name = "textBoxOdredisni";
            this.textBoxOdredisni.Size = new System.Drawing.Size(299, 20);
            this.textBoxOdredisni.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonPokreni
            // 
            this.buttonPokreni.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPokreni.Location = new System.Drawing.Point(12, 144);
            this.buttonPokreni.Name = "buttonPokreni";
            this.buttonPokreni.Size = new System.Drawing.Size(519, 50);
            this.buttonPokreni.TabIndex = 6;
            this.buttonPokreni.Text = "Pokreni";
            this.buttonPokreni.UseVisualStyleBackColor = true;
            this.buttonPokreni.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 206);
            this.Controls.Add(this.buttonPokreni);
            this.Controls.Add(this.buttonOdr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxOdredisni);
            this.Controls.Add(this.buttonIzv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIzvorni);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIzvorni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonIzv;
        private System.Windows.Forms.Button buttonOdr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOdredisni;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonPokreni;
    }
}

