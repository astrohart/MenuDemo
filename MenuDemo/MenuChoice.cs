using System.ComponentModel;
using System.Runtime.Serialization;

namespace MenuDemo
{
    /// <summary>
    /// Values that define the choices of the menu.
    /// </summary>
    /// <remarks>
    /// Each of the values of this <see langword="enum" /> represents a
    /// command that you can give the application.
    /// <para />
    /// The name of each value represents the command.
    /// <para />
    /// The value of the corresponding
    /// <see cref="T:System.ComponentModel.DescriptionAttribute" /> gives freeform text
    /// that can be displayed as the human-readable name of the command.
    /// <para />
    /// The <see cref="T:System.Runtime.Serialization.EnumMemberAttribute" /> makes
    /// this <see langword="enum" /> serializable, e.g., to and from JSON, should
    /// such an operation be desirable to be performed (e.g., to make the commands
    /// configurable).
    /// </remarks>
    public enum MenuChoices
    {
        /// <summary>
        /// Represents the action of eating candy.
        /// </summary>
        [Description("Eat Candy"), EnumMember(Value = "Eat Candy")]
        EatCandy,
        
        /// <summary>
        /// Represents the action of going fishing.
        /// </summary>
        [Description("Go Fishing"), EnumMember(Value = "Go Fishing")]
        GoFishing,

        /// <summary>
        /// Represents the action of playing basketball.
        /// </summary>
        [Description("Play Basketball"), EnumMember(Value = "Play Basketball")]
        PlayBasketball,

        /// <summary>
        /// Exits the application.
        /// </summary>
        [Description("Exit"), EnumMember(Value = "Exit")]
        Exit,

        /// <summary>
        /// Represents an unknown or invalid choice.
        /// </summary>
        Unknown = -1
    }
}