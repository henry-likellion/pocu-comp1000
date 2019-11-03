using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    public static class FilterEngine
    {
        public static List<Frame> FilterFrames(List<Frame> frames, EFeatures features)
        {
            List<Frame> filteredFrames = new List<Frame>();

            for (int i = 0; i < frames.Count; ++i)
            {
                Console.WriteLine(frames[i].Features);
                if ((frames[i].Features & features) != 0)
                {
                    filteredFrames.Add(frames[i]);
                }
            }
            return filteredFrames;
        }

        public static List<Frame> FilterOutFrames(List<Frame> frames, EFeatures features)
        {
            List<Frame> filteredFrames = new List<Frame>();

            for (int i = 0; i < frames.Count; ++i)
            {
                Console.WriteLine(frames[i].Features);
                if ((frames[i].Features & features) == 0)
                {
                    filteredFrames.Add(frames[i]);
                }
            }
            return filteredFrames;
        }

        public static List<Frame> Intersect(List<Frame> frames1, List<Frame> frames2)
        {
            List<Frame> intersectionFrames = new List<Frame>();
            for (int i = 0; i < frames1.Count; ++i)
            {
                for (int j = 0; j < frames2.Count; ++j)
                {
                    if (frames1[i].Name == frames2[j].Name && frames1[i].Features == frames2[j].Features)
                    {
                        intersectionFrames.Add(frames1[i]);
                    }
                }
            }

            return intersectionFrames;
        }

        public static List<int> GetSortKeys(List<Frame> frames, List<EFeatures> features)
        {
            List<int> framesKeys = new List<int>(frames.Count);

            for (int i = 0; i < frames.Count; ++i)
            {
                framesKeys.Add(0);

                for (int j = 0; j < features.Count; ++j)
                {
                    if ((frames[i].Features & features[j]) == features[j])
                    {
                        if (j == 0)
                        {
                            framesKeys[i] += 128;
                        }
                        else if (j == 1)
                        {
                            framesKeys[i] += 64;
                        }
                        else if (j == 2)
                        {
                            framesKeys[i] += 32;
                        }
                        else if (j == 3)
                        {
                            framesKeys[i] += 16;
                        }
                        else if (j == 4)
                        {
                            framesKeys[i] += 8;
                        }
                        else if (j == 5)
                        {
                            framesKeys[i] += 4;
                        }
                        else if (j == 6)
                        {
                            framesKeys[i] += 2;
                        }
                        else if (j == 7)
                        {
                            framesKeys[i] += 1;
                        }
                    }
                }
            }

            return framesKeys;
        }
    }
}
