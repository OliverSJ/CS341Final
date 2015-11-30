namespace FinalProject
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
      this.pushPin_listBox = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // pushPin_listBox
      // 
      this.pushPin_listBox.FormattingEnabled = true;
      this.pushPin_listBox.Location = new System.Drawing.Point(12, 12);
      this.pushPin_listBox.Name = "pushPin_listBox";
      this.pushPin_listBox.Size = new System.Drawing.Size(260, 238);
      this.pushPin_listBox.TabIndex = 0;
      this.pushPin_listBox.SelectedIndexChanged += new System.EventHandler(this.pushPin_listBox_SelectedIndexChanged);
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 262);
      this.Controls.Add(this.pushPin_listBox);
      this.Name = "Form2";
      this.Text = "Form2";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox pushPin_listBox;
  }
}