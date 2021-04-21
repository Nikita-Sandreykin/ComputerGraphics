namespace ComputerGraphics
{
    partial class TestObj
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

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(803, 837);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(822, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 81);
            this.button1.TabIndex = 1;
            this.button1.Text = "Points";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.rawPoints);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(822, 241);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 81);
            this.button2.TabIndex = 1;
            this.button2.Text = "Polygons";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.rawPolygons);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(822, 373);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(156, 81);
            this.button3.TabIndex = 2;
            this.button3.Text = "Raw triangles ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.rawTriangles);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(822, 501);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(156, 81);
            this.button4.TabIndex = 3;
            this.button4.Text = "Basic lighting";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.basicLighting);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(822, 636);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(156, 81);
            this.button5.TabIndex = 4;
            this.button5.Text = "Z buffer";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.zBuffer);
            // TestObj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 837);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TestObj";
            this.Text = "TestObj";
            this.Load += new System.EventHandler(this.TestObj_Load);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponentWithMoving()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(803, 837);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(822, 56);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(56, 41);
            this.button6.TabIndex = 6;
            this.button6.Text = "Учесть поворот";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.turn);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(822, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 81);
            this.button1.TabIndex = 1;
            this.button1.Text = "Points";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.rawPoints);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(822, 241);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 81);
            this.button2.TabIndex = 1;
            this.button2.Text = "Polygons";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.rawPolygons);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(822, 373);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(156, 81);
            this.button3.TabIndex = 2;
            this.button3.Text = "Raw triangles ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.rawTriangles);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(822, 501);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(156, 81);
            this.button4.TabIndex = 3;
            this.button4.Text = "Basic lighting";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.basicLighting);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(822, 636);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(156, 81);
            this.button5.TabIndex = 4;
            this.button5.Text = "Z buffer";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.zBuffer);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(961, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(961, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(35, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(961, 75);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(35, 20);
            this.textBox3.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(939, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(939, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(939, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Z";
            // 
            // TestObj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 837);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TestObj";
            this.Text = "TestObj";
            this.Load += new System.EventHandler(this.TestObj_Load);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;

        private System.Windows.Forms.Button button3;

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}