using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SonderSollutionsXM.ListPushing
{
    /// <summary>
    /// This Static Class Allows The Use Of 'Pushing' For Typeof List of Any type and kind.
    /// Pushing -- Moving All Values inside of list from bottom (end) to top (beginning index 0)
    /// then overwriting last index position with the desired item.
    /// </summary>
    public static class ExList
    {
        /// <summary>
        /// (List Must Have At-lease 2 items) Will Overwrite Desired Item at the End Of List. After moving all current values in list from the bottom (end index)
        /// to the top (beginning index 0).
        /// Example (list of 4 indexes), 0 = 1, 1 = 2, 2 = 3, 3 = desired Item Wanting To Add into the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ListToPush">The List You Want Pushed</param>
        /// <param name="Item">The Item That Will Be Pushed Into The List Provided</param>
        public static void PushFromEnd<T>(this List<T> ListToPush, T Item)
        {
            PushProcess_FromEnd(ListToPush, Item);
        }


        /// <summary>
        /// (List Must Have At-lease 2 items) Will over Item at desired index position. After moving all current values in list from desired index provided (PushAtIndex)
        /// to the top (beginning index 0).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ListToPush">The List You Want Pushed</param>
        /// <param name="Item">The Item That Will Be Pushed Into The List Provided</param>
        /// <param name="PushAtIndex">The index to begin the pushing process</param>
        public static void PushAtIndex<T>(this List<T> ListToPush, T Item, int PushAtIndex)
        {
            PushProcess_AtIndex(ListToPush, Item, PushAtIndex);
        }

        private static async void PushProcess_FromEnd<K>(List<K> PushList, K Item)
        {
            if (PushList.Count == 0 || PushList.Count == 1)
            {
                throw new Exception("Your List Has Nothing inside to push. List must have at-lease 2 items inside.");
            }

            await Task.Run(() =>
            {
                for (int i = 0; i < PushList.Count; i++)
                {
                    if (i != PushList.Count - 1)
                    {//Not On Last Index
                        PushList[i] = PushList[i + 1];
                    }
                    else
                    {//On Last Index
                        PushList[i - 1] = PushList[i];
                    }

                }

                //Reach Last Item In List
                PushList[PushList.Count - 1] = Item;

            });
        }

        private static async void PushProcess_AtIndex<K>(List<K> PushList, K Item, int IndexPosition)
        {
            if (IndexPosition >= PushList.Count || IndexPosition < 0)
            {
                throw new Exception("Your IndexPosition value provided Is greater than the acutal total of items in your list. Or Your IndexPosition Value Provided Is Less 0. Remember, IndexPostion Value is a ZeroBased Value");
            }

            if (PushList.Count == 0 || PushList.Count == 1)
            {
                throw new Exception("Your List Has Nothing inside to push. List must have at-lease 2 items inside.");
            }

            await Task.Run(() =>
            {
                for (int i = 0; i < IndexPosition; i++)
                {
                    PushList[i] = PushList[i + 1];
                }

                //Reach Last Index Position Item
                PushList[IndexPosition] = Item;
            });
        }


    }
}
