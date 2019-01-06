using UnityEngine.UI;

namespace BlendModes
{
    [ExtendedComponent(typeof(Image))]
    public class UIImageExtension : MaskableGraphicExtension<Image>
    {
        public override string[] GetSupportedShaderFamilies ()
        {
            return new[] {
                "UIDefault"
            };
        }
    }
}
