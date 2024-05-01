
namespace Kurs2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rules = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gradientTimer = new System.Windows.Forms.Timer(this.components);
            this.move = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.catBox = new System.Windows.Forms.PictureBox();
            this.cat = new System.Windows.Forms.Timer(this.components);
            this.ghostTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(484, 501);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // rules
            // 
            this.rules.BackColor = System.Drawing.Color.Black;
            this.rules.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.rules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rules.Font = new System.Drawing.Font("Klaxons", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rules.ForeColor = System.Drawing.Color.White;
            this.rules.Location = new System.Drawing.Point(169, 245);
            this.rules.Name = "rules";
            this.rules.Size = new System.Drawing.Size(130, 46);
            this.rules.TabIndex = 2;
            this.rules.Text = "Rules";
            this.rules.UseVisualStyleBackColor = false;
            this.rules.Click += new System.EventHandler(this.rules_Click);
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.Black;
            this.start.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start.Font = new System.Drawing.Font("Klaxons", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.start.ForeColor = System.Drawing.Color.White;
            this.start.Location = new System.Drawing.Point(169, 324);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(130, 46);
            this.start.TabIndex = 3;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Klaxons", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(107, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 67);
            this.label1.TabIndex = 5;
            this.label1.Text = "Go! Cat";
            // 
            // gradientTimer
            // 
            this.gradientTimer.Tick += new System.EventHandler(this.gradientTimer_Tick);
            // 
            // move
            // 
            this.move.Tick += new System.EventHandler(this.move_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(212, 69);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // catBox
            // 
            this.catBox.BackColor = System.Drawing.Color.Transparent;
            this.catBox.Image = ((System.Drawing.Image)(resources.GetObject("catBox.Image")));
            this.catBox.Location = new System.Drawing.Point(38, 25);
            this.catBox.Name = "catBox";
            this.catBox.Size = new System.Drawing.Size(30, 30);
            this.catBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.catBox.TabIndex = 8;
            this.catBox.TabStop = false;
            this.catBox.Visible = false;
            // 
            // cat
            // 
            this.cat.Tick += new System.EventHandler(this.cat_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(484, 500);
            this.Controls.Add(this.catBox);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.rules);
            this.Controls.Add(this.start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Go Cat!";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button rules;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer gradientTimer;
        private System.Windows.Forms.Timer move;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox catBox;
        private System.Windows.Forms.Timer cat;
        private System.Windows.Forms.Timer ghostTimer;
    }
}

