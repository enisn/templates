using System;
using CarPlay;
using Foundation;
using UIKit;

namespace ShinyApp.iOS.CarPlayImplementation;


[Register("CarPlaySceneDelegate")]
public class CarPlaySceneDelegate : CPTemplateApplicationSceneDelegate
{
    CPInterfaceController controller = null!;
    readonly CPTabBarTemplate tabBarTemplate;
    readonly CPGridTemplate gridTemplate;


	public CarPlaySceneDelegate()
	{
        this.gridTemplate = new CPGridTemplate("Hello World", new CPGridButton[] { })
        {
            TabImage = UIImage.GetSystemImage("circle.grid.3x3.fill")  
        };
        this.tabBarTemplate = new CPTabBarTemplate(new CPTemplate[] { this.gridTemplate });
	}


    public override void DidConnect(CPTemplateApplicationScene templateApplicationScene, CPInterfaceController interfaceController)
    {
        base.DidConnect(templateApplicationScene, interfaceController);
        this.controller = interfaceController;
        this.controller.SetRootTemplate(this.tabBarTemplate, true);
    }


    public override void DidDisconnect(CPTemplateApplicationScene templateApplicationScene, CPInterfaceController interfaceController)
    {
        base.DidDisconnect(templateApplicationScene, interfaceController);
        this.controller?.Dispose();
    }
}