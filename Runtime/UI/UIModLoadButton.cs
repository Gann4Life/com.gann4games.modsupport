using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Gann4Games.ModSupport
{
    public class UIModLoadButton : MonoBehaviour
    {
        [FormerlySerializedAs("Name")] [Tooltip("UI Text item that will display the mod's name.")] [SerializeField]
        private TextMeshProUGUI modNameTextField;

        [FormerlySerializedAs("Description")]
        [Tooltip("UI Text item that will display the mod's description.")]
        [SerializeField]
        private TextMeshProUGUI modNameDescriptionField;

        [Tooltip("Raw Image component that will display the mod's thumbnail.")] 
        [SerializeField] private RawImage modThumbnail;

        private ModInfo _modInformation;
        private UIModBrowser _modBrowser;

        /// <summary>
        /// Configures the prefab to load the provided mod, then display the mod's name and description.
        /// </summary>
        /// <param name="modInfo">The mod to load</param>
        /// <param name="modBrowser"></param>
        public void SetModToLoad(ModInfo modInfo, UIModBrowser modBrowser)
        {
            _modBrowser = modBrowser;
            
            _modInformation = modInfo;
            modNameTextField.text = modInfo.GetModName();
            modNameDescriptionField.text = modInfo.GetModDescription();
            if(modInfo.HasThumbnail()) modThumbnail.texture = modInfo.GetModThumbnainTexture();
        }

        /// <summary>
        /// Tells the mod manager to select this mod.
        /// </summary>
        public void SelectThisMod()
        {
            _modBrowser.SelectMod(_modInformation);
        }
    }
}