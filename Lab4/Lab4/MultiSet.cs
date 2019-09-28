using System.Collections.Generic;

namespace Lab4
{
    public sealed class MultiSet
    {
        private List<string> Set = new List<string>();

        public void Add(string element)
        {
            Set.Add(element);
        }

        public bool Remove(string element)
        {
            return Set.Remove(element);
        }

        public uint GetMultiplicity(string element)
        {
            uint count = 0;
            foreach (string el in Set)
            {
                if (el == element)
                {
                    ++count;
                }
            }
            return count;
        }

        public List<string> ToList()
        {
            Set.Sort();
            return Set;
        }

        public MultiSet Union(MultiSet other)
        {
            List<string> elementsChecked = new List<string>();
            MultiSet union = new MultiSet();

            foreach (string el in Set)
            {
                if (!elementsChecked.Contains(el))
                {
                    elementsChecked.Add(el);
                }
            }

            foreach (string el in other.ToList())
            {
                if (!elementsChecked.Contains(el))
                {
                    elementsChecked.Add(el);
                }
            }

            foreach (string el in elementsChecked)
            {
                uint set1EliMultiplicity = GetMultiplicity(el);
                uint set2EliMultiplicity = other.GetMultiplicity(el);
                uint maxMultiplicity = (set1EliMultiplicity > set2EliMultiplicity) ? set1EliMultiplicity : set2EliMultiplicity;

                for (int i = 0; i < maxMultiplicity; ++i)
                {
                    union.Add(el);
                }
            }

            return union;
        }

        public MultiSet Intersect(MultiSet other)
        {
            List<string> elementsChecked = new List<string>();
            MultiSet intersect = new MultiSet();

            foreach (string el in Set)
            {
                if (!elementsChecked.Contains(el))
                {
                    elementsChecked.Add(el);

                    uint set1EliMultiplicity = GetMultiplicity(el);
                    uint set2EliMultiplicity = other.GetMultiplicity(el);
                    uint minMultiplicity = (set1EliMultiplicity < set2EliMultiplicity) ? set1EliMultiplicity : set2EliMultiplicity;

                    for (int i = 0; i < minMultiplicity; ++i)
                    {
                        intersect.Add(el);
                    }
                }
            }

            return intersect;
        }

        public MultiSet Subtract(MultiSet other)
        {
            List<string> elementsChecked = new List<string>();
            MultiSet difference = new MultiSet();

            foreach (string el in Set)
            {
                if (!elementsChecked.Contains(el))
                {
                    elementsChecked.Add(el);

                    uint set1EliMultiplicity = GetMultiplicity(el);
                    uint set2EliMultiplicity = other.GetMultiplicity(el);
                    uint differenceMultiplicity = (set1EliMultiplicity > set2EliMultiplicity) ? set1EliMultiplicity - set2EliMultiplicity : 0;

                    for (int i = 0; i < differenceMultiplicity; ++i)
                    {
                        difference.Add(el);
                    }
                }
            }

            return difference;
        }

        public List<MultiSet> FindPowerSet()
        {

            Set.Sort();
            List<string> sortedElementsNoRepeat = new List<string>();
            List<int> elementCounts = new List<int>();

            string currentElement = Set[0];
            int counter = 1;

            for (int i = 1; i < Set.Count; ++i)
            {
                if (currentElement == Set[i])
                {
                    ++counter;
                }
                else
                {
                    sortedElementsNoRepeat.Add(currentElement);
                    elementCounts.Add(counter);

                    currentElement = Set[i];
                    counter = 1;
                }

                if (i == Set.Count - 1)
                {
                    sortedElementsNoRepeat.Add(currentElement);
                    elementCounts.Add(counter);
                }
            }

            int numMultiSets = 1;

            foreach (int count in elementCounts)
            {
                numMultiSets *= count + 1;
            }

            List<MultiSet> powerSet = new List<MultiSet>(numMultiSets);

            for (int i = 0; i < powerSet.Capacity; ++i)
            {
                powerSet.Add(new MultiSet());
            }

            AddElementsPowerSetRecursive(powerSet, sortedElementsNoRepeat, elementCounts, 0, 1, numMultiSets - 1);

            return powerSet;
        }

        public bool IsSubsetOf(MultiSet other)
        {
            MultiSet primarySet = new MultiSet();

            foreach (string element in Set)
            {
                primarySet.Add(element);
            }

            MultiSet difference = primarySet.Subtract(other);

            if (difference.ToList().Count == 0)
            {
                return true;
            }
            return false;
        }

        public bool IsSupersetOf(MultiSet other)
        {
            MultiSet primarySet = new MultiSet();

            foreach (string element in Set)
            {
                primarySet.Add(element);
            }

            MultiSet difference = other.Subtract(primarySet);

            if (difference.ToList().Count == 0)
            {
                return true;
            }
            return false;
        }

        public void AddElementsPowerSetRecursive(List<MultiSet> powerSet, List<string> sortedElementsNoRepeat, List<int> elementCounts, int elementIndex, int startPowerSet, int endPowerSet)
        {
            string currentString = sortedElementsNoRepeat[elementIndex];
            int currentStringCount = elementCounts[elementIndex];
            int currentIndexPowerSet = startPowerSet;

            for (int i = 0; i < currentStringCount; ++i)
            {
                for (int j = 0; j <= i; ++j)
                {
                    powerSet[currentIndexPowerSet].Add(currentString);
                }
                ++currentIndexPowerSet;
            }

            int repeatCount = (endPowerSet - startPowerSet + 1) / (currentStringCount + 1);

            for (int i = currentStringCount; i >= 0; --i)
            {
                int nextStringStartPowerSet = currentIndexPowerSet;
                for (int j = 0; j < repeatCount; ++j)
                {
                    for (int k = 1; k <= i; ++k)
                    {
                        powerSet[currentIndexPowerSet].Add(currentString);
                    }
                    ++currentIndexPowerSet;
                }

                if (elementIndex + 1 < elementCounts.Count)
                {
                    AddElementsPowerSetRecursive(powerSet, sortedElementsNoRepeat, elementCounts, elementIndex + 1, nextStringStartPowerSet, currentIndexPowerSet - 1);
                }
            }

        }
    }
}