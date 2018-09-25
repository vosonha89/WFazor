namespace WFazorTest
{
    partial class MainForm
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
            this.wFazorBrowser1 = new WFazor.WFazorBrowser();
            this.SuspendLayout();
            // 
            // wFazorBrowser1
            // 
            this.wFazorBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wFazorBrowser1.Location = new System.Drawing.Point(0, 0);
            this.wFazorBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.wFazorBrowser1.Name = "wFazorBrowser1";
            this.wFazorBrowser1.ScrollBarsEnabled = false;
            this.wFazorBrowser1.Size = new System.Drawing.Size(800, 450);
            this.wFazorBrowser1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wFazorBrowser1);
            this.Name = "MainForm";
            this.Text = "WFazor";
            this.ResumeLayout(false);

        }

        #endregion

        private WFazor.WFazorBrowser wFazorBrowser1;
    }
}

