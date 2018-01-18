# Xamarin-KVO-bug-demo
Demo of bug with Xamarin Mac KVO bindings

Binding Observer fires twice when bound to Xcode UI component.


The main area is here:

[ViewController.cs](ViewController.cs)

When the app boots, `CheckValue` is programatically set, which triggers ONE observer call (and one log to the text area)

But when you press the check box, it triggers TWO observer calls, and logs twice to the text area.


(1.png)

(1.png)


