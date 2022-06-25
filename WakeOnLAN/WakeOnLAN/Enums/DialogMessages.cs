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
            [Description("Un nom d'ordinateur doit être entrée.")]
            ERR_COMPUTER_NAME_EMPTY = 0,

            [Description("Une adresse mac doit être entrée.")]
            ERR_MAC_ADDRESS_EMPTY = 1,

            [Description("L'adresse mac entrée n'est pas valide.")]
            ERR_MAC_ADDRESS_INVALID = 2,

            [Description("Un groupe doit être choisis.")]
            ERR_GROUP_NOT_SELECTED = 3,

            [Description("Un nom de local doit être entrée.")]
            ERR_LOCAL_EMPTY = 4,

            [Description("Un nom de VLAN doit être entrée.")]
            ERR_VLAN_EMPTY = 5,
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
