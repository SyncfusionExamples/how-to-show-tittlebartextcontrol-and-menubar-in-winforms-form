# How to show TittleBarTextControl and menubar in WinForms Form(SfForm)?

## About the sample
This example illustrates how to show TittleBarTextControl and menubar in WinForms Form(SfForm)

SfForm allows you to load any user control into the title bar instead of title bar text by using the TitleBarTextControl property. While adding MenuBar to the form's controls collection when TitleBarTextControl is enabled, it will be docked to top of the form and overlapped with the TitleBarTextControl . This can be resolved by setting top padding for the Form.

```C#

public Form1()
{
    InitializeComponent();
    this.Padding = new Padding(0, this.Style.TitleBar.Height, 0, 0);
}

```
## Requirements to run the demo
Visual Studio 2015 and above versions

