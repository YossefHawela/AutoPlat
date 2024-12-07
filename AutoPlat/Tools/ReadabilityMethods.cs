using AutoPlat.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPlat.Tools
{

    /// <summary>
    /// Some methols to make the code more readable.
    /// </summary>
    internal static class ReadabilityMethods
    {

        /// <summary>
        /// return true if every condition is met and false if every condition is not met otherwise null.
        /// </summary>
        /// <param name="conditions">The conditions to check</param>
        /// <returns></returns>
        internal static bool? Every(ReadOnlyCollection<Condition> conditions) => 
            conditions.All(cond => cond.Met) ? true : conditions.All(cond => !cond.Met) ? false : null;

        /// <summary>
        /// return true if any condition is  false
        /// </summary>
        /// <param name="conditions">The conditions to check</param>
        /// <returns></returns>
        internal static bool ThireIsAnyFalseCondition(ReadOnlyCollection<Condition> conditions) =>
            conditions.Any(cond => !cond.Met);


        /// <summary>
        /// return true if any condition is true
        /// </summary>
        /// <param name="conditions">The conditions to check</param>
        /// <returns></returns>
        internal static bool ThireIsAnyTrueCondition(ReadOnlyCollection<Condition> conditions) =>
            conditions.Any(cond => cond.Met);
    }
}
