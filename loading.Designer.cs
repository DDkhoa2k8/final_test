namespace final_test
{
    partial class loading
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loading));
            this.loadingBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.image = new Guna.UI2.WinForms.Guna2ImageButton();
            this.label1 = new System.Windows.Forms.Label();
            this.text_timer = new System.Windows.Forms.Timer(this.components);
            this.con = new System.Windows.Forms.TableLayoutPanel();
            this.con.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadingBar
            // 
            this.loadingBar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loadingBar.Location = new System.Drawing.Point(109, 488);
            this.loadingBar.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(737, 35);
            this.loadingBar.TabIndex = 0;
            this.loadingBar.Text = "guna2ProgressBar1";
            this.loadingBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.loadingBar.ValueChanged += new System.EventHandler(this.loadingBar_ValueChanged);
            // 
            // image
            // 
            this.image.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.image.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("image.BackgroundImage")));
            this.image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.image.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.image.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.image.ImageOffset = new System.Drawing.Point(0, 0);
            this.image.ImageRotate = 0F;
            this.image.Location = new System.Drawing.Point(3, 3);
            this.image.Name = "image";
            this.image.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.image.Size = new System.Drawing.Size(950, 391);
            this.image.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(396, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đang tải...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // con
            // 
            this.con.ColumnCount = 1;
            this.con.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.con.Controls.Add(this.loadingBar, 0, 2);
            this.con.Controls.Add(this.image, 0, 0);
            this.con.Controls.Add(this.label1, 0, 1);
            this.con.Dock = System.Windows.Forms.DockStyle.Fill;
            this.con.Location = new System.Drawing.Point(0, 0);
            this.con.Name = "con";
            this.con.RowCount = 3;
            this.con.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 397F));
            this.con.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.con.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.con.Size = new System.Drawing.Size(956, 552);
            this.con.TabIndex = 3;
            // 
            // loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(956, 552);
            this.Controls.Add(this.con);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "loading";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "loading";
            this.Load += new System.EventHandler(this.loading_Load);
            this.con.ResumeLayout(false);
            this.con.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ProgressBar loadingBar;
        private System.Windows.Forms.Timer timer;
        private Guna.UI2.WinForms.Guna2ImageButton image;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer text_timer;
        private System.Windows.Forms.TableLayoutPanel con;
    }
}