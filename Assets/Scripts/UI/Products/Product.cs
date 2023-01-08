using UnityEngine;

namespace UI.Products
{
    [CreateAssetMenu(fileName = "Product", menuName = "UI SO/New Product")]
    public class Product : ScriptableObject
    {
        public Sprite Icon;
        public string Title;
        public string Description;
        public int Price;
    }
}
