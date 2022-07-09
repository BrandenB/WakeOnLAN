/**
* Author: Branden Brideau
* Date: June 2022
*/
using System.ComponentModel;

namespace WakeOnLAN.Enums
{
    internal static class DialogMessages
    {

        /// <summary>
        /// All possible error message for all forms.
        /// </summary>
        internal enum DialogMessage
        {
            [Description("Erreur")]
            ERR_TITLE = 0,

            [Description("Information")]
            INFO_TITLE = 1,

            [Description("Un nom d'ordinateur doit être entrée.")]
            ERR_COMPUTER_NAME_EMPTY = 2,

            [Description("Une adresse mac doit être entrée.")]
            ERR_MAC_ADDRESS_EMPTY = 3,

            [Description("L'adresse mac entrée n'est pas valide.")]
            ERR_MAC_ADDRESS_INVALID = 4,

            [Description("Un groupe doit être choisis.")]
            ERR_GROUP_NOT_SELECTED = 5,

            [Description("Un nom de local doit être entrée.")]
            ERR_LOCAL_EMPTY = 6,

            [Description("Un nom de VLAN doit être entrée.")]
            ERR_VLAN_EMPTY = 7,

            [Description("Tous les ordinateurs de ce groupe ont été réveillés.")]
            INFO_WAKE_UP_COMPLETED = 8,

            [Description("Un nom de groupe doit être entrée.")]
            ERR_COMPUTER_GROUP_EMPTY = 9,

            [Description("Le fichier xml n'existe pas. Voulez vous q'un soit crée automatiquement ?")]
            ERR_XML_NOT_FOUND = 10,

            [Description("Le groupe a été suprimer !")]
            CON_GROUP_DELETED = 11,

            [Description("Êtes-vous sûr de vouloir supprimer cet ordinateur de la liste ?")]
            CON_COMPUTER_DELETION = 12,

            [Description("Êtes-vous sûr de vouloir réveiller cet ordinateur ?")]
            CON_COMPUTER_WAKEUP = 13,

            [Description("L'ordinateur sélectionné a été réveiller !")]
            CON_COMPUTER_WOKEUP = 14,
        }

        #region Public methods

        /// <summary>
        /// Gets the description of the enum.
        /// </summary>
        /// <param name="a"></param>
        public static string GetMessage(this DialogMessage a)
        {
            DescriptionAttribute? att = a.GetType()
                .GetField(a.ToString())?
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault()
                as DescriptionAttribute;

            return att?.Description ?? a.ToString();
        }

        #endregion
    }
}
