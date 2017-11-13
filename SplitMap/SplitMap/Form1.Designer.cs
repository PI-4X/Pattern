namespace SplitMap
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonDrawMap = new System.Windows.Forms.Button();
            this.buttonDrawAbility = new System.Windows.Forms.Button();
            this.buttonCreateAnimal = new System.Windows.Forms.Button();
            this.buttonDrawActionAbility = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonActionDecorator = new System.Windows.Forms.Button();
            this.buttonCreateAction = new System.Windows.Forms.Button();
            this.buttonAddComponent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(12, 11);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1000, 500);
            this.panelMain.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1019, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Find banana";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonDrawMap
            // 
            this.buttonDrawMap.Location = new System.Drawing.Point(1099, 13);
            this.buttonDrawMap.Name = "buttonDrawMap";
            this.buttonDrawMap.Size = new System.Drawing.Size(75, 46);
            this.buttonDrawMap.TabIndex = 2;
            this.buttonDrawMap.Text = "Reset map";
            this.buttonDrawMap.UseVisualStyleBackColor = true;
            this.buttonDrawMap.Click += new System.EventHandler(this.buttonDrawMap_Click);
            // 
            // buttonDrawAbility
            // 
            this.buttonDrawAbility.Location = new System.Drawing.Point(1099, 135);
            this.buttonDrawAbility.Name = "buttonDrawAbility";
            this.buttonDrawAbility.Size = new System.Drawing.Size(75, 48);
            this.buttonDrawAbility.TabIndex = 3;
            this.buttonDrawAbility.Text = "Draw Abilities";
            this.buttonDrawAbility.UseVisualStyleBackColor = true;
            this.buttonDrawAbility.Click += new System.EventHandler(this.buttonDrawAbility_Click);
            // 
            // buttonCreateAnimal
            // 
            this.buttonCreateAnimal.Location = new System.Drawing.Point(1019, 65);
            this.buttonCreateAnimal.Name = "buttonCreateAnimal";
            this.buttonCreateAnimal.Size = new System.Drawing.Size(75, 64);
            this.buttonCreateAnimal.TabIndex = 4;
            this.buttonCreateAnimal.Text = "Create Animal";
            this.buttonCreateAnimal.UseVisualStyleBackColor = true;
            this.buttonCreateAnimal.Click += new System.EventHandler(this.buttonCreateAnimal_Click);
            // 
            // buttonDrawActionAbility
            // 
            this.buttonDrawActionAbility.Location = new System.Drawing.Point(1019, 135);
            this.buttonDrawActionAbility.Name = "buttonDrawActionAbility";
            this.buttonDrawActionAbility.Size = new System.Drawing.Size(75, 48);
            this.buttonDrawActionAbility.TabIndex = 5;
            this.buttonDrawActionAbility.Text = "Draw Action Abilities";
            this.buttonDrawActionAbility.UseVisualStyleBackColor = true;
            this.buttonDrawActionAbility.Click += new System.EventHandler(this.buttonDrawActionAbility_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 517);
            this.trackBar1.Maximum = 199;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(1000, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(1059, 353);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(75, 23);
            this.buttonUp.TabIndex = 8;
            this.buttonUp.Text = "Up";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(1059, 430);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(75, 23);
            this.buttonDown.TabIndex = 9;
            this.buttonDown.Text = "Down";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(1018, 391);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(75, 23);
            this.buttonLeft.TabIndex = 10;
            this.buttonLeft.Text = "Left";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(1099, 391);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(75, 23);
            this.buttonRight.TabIndex = 11;
            this.buttonRight.Text = "Right";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // buttonActionDecorator
            // 
            this.buttonActionDecorator.Location = new System.Drawing.Point(1019, 488);
            this.buttonActionDecorator.Name = "buttonActionDecorator";
            this.buttonActionDecorator.Size = new System.Drawing.Size(155, 23);
            this.buttonActionDecorator.TabIndex = 12;
            this.buttonActionDecorator.Text = "Change Color";
            this.buttonActionDecorator.UseVisualStyleBackColor = true;
            this.buttonActionDecorator.Click += new System.EventHandler(this.buttonActionDecorator_Click);
            // 
            // buttonCreateAction
            // 
            this.buttonCreateAction.Location = new System.Drawing.Point(1099, 65);
            this.buttonCreateAction.Name = "buttonCreateAction";
            this.buttonCreateAction.Size = new System.Drawing.Size(75, 64);
            this.buttonCreateAction.TabIndex = 13;
            this.buttonCreateAction.Text = "Create random action";
            this.buttonCreateAction.UseVisualStyleBackColor = true;
            this.buttonCreateAction.Click += new System.EventHandler(this.buttonCreateAction_Click);
            // 
            // buttonAddComponent
            // 
            this.buttonAddComponent.Location = new System.Drawing.Point(1018, 189);
            this.buttonAddComponent.Name = "buttonAddComponent";
            this.buttonAddComponent.Size = new System.Drawing.Size(75, 48);
            this.buttonAddComponent.TabIndex = 15;
            this.buttonAddComponent.Text = "Add component";
            this.buttonAddComponent.UseVisualStyleBackColor = true;
            this.buttonAddComponent.Click += new System.EventHandler(this.buttonAddComponent_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 570);
            this.Controls.Add(this.buttonAddComponent);
            this.Controls.Add(this.buttonCreateAction);
            this.Controls.Add(this.buttonActionDecorator);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.buttonDrawActionAbility);
            this.Controls.Add(this.buttonCreateAnimal);
            this.Controls.Add(this.buttonDrawAbility);
            this.Controls.Add(this.buttonDrawMap);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDrawMap;
        private System.Windows.Forms.Button buttonDrawAbility;
        private System.Windows.Forms.Button buttonCreateAnimal;
        private System.Windows.Forms.Button buttonDrawActionAbility;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonActionDecorator;
        private System.Windows.Forms.Button buttonCreateAction;
        private System.Windows.Forms.Button buttonAddComponent;
    }
}

