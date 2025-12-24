# How to Show TitleBarTextControl and Menubar in WinForms Form?

This example illustrates how to show [TitleBarTextControl](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.Controls.SfForm.html#Syncfusion_WinForms_Controls_SfForm_TitleBarTextControl) and Menubar in [WinForms Form](https://www.syncfusion.com/winforms-ui-controls/form) (SfForm).

`Form` allows you to load any user control into the title bar instead of title bar text by using the `TitleBarTextControl` property. While adding MenuBar to the form's controls collection when `TitleBarTextControl` is enabled, it will be docked to top of the form and overlapped with the `TitleBarTextControl` . This can be resolved by setting top padding for the Form.

```C#
public Form1()
{
    InitializeComponent();
    this.Padding = new Padding(0, this.Style.TitleBar.Height, 0, 0);
}
```

The following screenshot illustrates the `TextBarTextControl` in `Form`,

![SfForm with TitleBarTextControl inside the Title bar](SfFormWithTitleBarTextControl.png)

The following screenshot illustrates the `MenuBar` in `Form`,

![SfForm with Menubar loaded below the title bar](SfFormWithMenuBar.png)