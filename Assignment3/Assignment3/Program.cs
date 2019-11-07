﻿using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> expectedValue1 = new List<int> { 100, 102, 112, 114, 116, 118, 120, 123, 125, 127, 130, 132, 135, 137, 139, 141, 143, 146, 148, 150, 153, 155, 158, 160, 162, 165, 167, 170 };
            List<int> expectedValue2 = new List<int> { 100, 102, 112, 115, 117, 120, 122, 124, 127, 129, 132, 134, 136, 139, 141, 143, 145, 147, 150, 152, 155, 157, 159, 162, 164, 166, 168, 170 };
            List<int> expectedValue3 = new List<int> { 100, 102, 112, 115, 116, 117, 117, 123, 122, 124, 128, 132, 138, 139, 143, 146, 151, 151, 161, 170 };

            int[] steps = new int[] { 100, 102, 112, 170 };

            INoise noise = new ZeroNoise();
            List<int> newSteps = StepMaker.MakeSteps(steps, noise);

            Debug.Assert(expectedValue1.Count == newSteps.Count);

            for (int i = 0; i < expectedValue1.Count; i++)
            {
                Debug.Assert(expectedValue1[i] == newSteps[i]);
            }

            noise = new ConstantNoise();
            newSteps = StepMaker.MakeSteps(steps, noise);

            Debug.Assert(expectedValue2.Count == newSteps.Count);

            for (int i = 0; i < expectedValue2.Count; i++)
            {
                Debug.Assert(expectedValue2[i] == newSteps[i]);
            }

            noise = new SineNoise();
            newSteps = StepMaker.MakeSteps(steps, noise);

            Debug.Assert(expectedValue3.Count == newSteps.Count);

            for (int i = 0; i < expectedValue3.Count; i++)
            {
                Debug.Assert(expectedValue3[i] == newSteps[i]);
            }

            steps = new int[] { 185, 380, 391 };
            noise = new SineNoise();
            newSteps = StepMaker.MakeSteps(steps, noise);

            for (int i = 0; i < newSteps.Count; i++)
            {
                Console.Write($"{newSteps[i]} ");
            }

            Console.WriteLine("");

            int[] testSteps = new int[] { 0, 1000, 2000, 3000, 4000 };
            newSteps = StepMaker.MakeSteps(testSteps, new SineNoise());
            List<int> expectedValue = new List<int> { 0, 4, 12, 20, 27, 25, 28, 31, 34, 41, 44, 53, 62, 71, 80, 87, 95, 103, 112, 119, 128, 137, 145, 153, 157, 163, 165, 167, 169, 169, 179, 186, 195, 200, 204, 212, 220, 227, 225, 228, 231, 234, 241, 245, 254, 263, 272, 281, 288, 296, 304, 313, 320, 329, 338, 347, 355, 359, 365, 367, 369, 371, 371, 381, 389, 398, 403, 407, 415, 423, 430, 428, 431, 434, 437, 444, 447, 456, 465, 474, 483, 491, 499, 507, 516, 523, 532, 541, 549, 557, 561, 567, 569, 571, 573, 573, 583, 591, 600, 605, 609, 617, 625, 632, 630, 633, 635, 638, 645, 648, 657, 666, 675, 684, 691, 699, 706, 715, 722, 731, 740, 748, 756, 760, 766, 768, 770, 772, 772, 782, 789, 798, 803, 807, 815, 823, 830, 828, 831, 833, 836, 843, 846, 855, 863, 872, 881, 888, 896, 904, 913, 920, 929, 937, 946, 953, 957, 963, 965, 967, 969, 969, 979, 986, 995, 1000, 1006, 1008, 1010, 1012, 1011, 1019, 1027, 1036, 1039, 1042, 1043, 1046, 1048, 1051, 1058, 1065, 1072, 1080, 1088, 1095, 1102, 1109, 1108, 1109, 1112, 1114, 1121, 1125, 1132, 1142, 1150, 1148, 1151, 1154, 1157, 1163, 1168, 1176, 1185, 1192, 1200, 1205, 1206, 1209, 1210, 1212, 1220, 1228, 1235, 1240, 1248, 1256, 1264, 1271, 1281, 1287, 1294, 1301, 1309, 1307, 1310, 1312, 1314, 1322, 1326, 1334, 1342, 1351, 1350, 1353, 1355, 1358, 1362, 1369, 1376, 1383, 1391, 1397, 1400, 1401, 1404, 1406, 1409, 1416, 1424, 1431, 1439, 1447, 1454, 1461, 1468, 1467, 1468, 1471, 1473, 1480, 1484, 1491, 1500, 1508, 1506, 1508, 1512, 1514, 1520, 1525, 1534, 1543, 1551, 1559, 1566, 1574, 1582, 1590, 1595, 1605, 1613, 1621, 1630, 1639, 1647, 1654, 1661, 1668, 1667, 1668, 1671, 1673, 1680, 1684, 1691, 1700, 1708, 1706, 1708, 1712, 1714, 1720, 1725, 1734, 1743, 1751, 1759, 1766, 1775, 1783, 1792, 1797, 1807, 1815, 1823, 1832, 1841, 1849, 1856, 1864, 1871, 1870, 1871, 1874, 1876, 1883, 1886, 1893, 1902, 1910, 1908, 1910, 1914, 1916, 1922, 1928, 1937, 1946, 1954, 1962, 1969, 1978, 1986, 1995, 2000, 2005, 2013, 2022, 2029, 2037, 2045, 2054, 2063, 2072, 2077, 2083, 2085, 2088, 2090, 2089, 2097, 2106, 2115, 2119, 2122, 2123, 2126, 2128, 2131, 2138, 2146, 2153, 2161, 2169, 2177, 2185, 2193, 2192, 2193, 2196, 2198, 2205, 2211, 2218, 2225, 2233, 2239, 2249, 2258, 2267, 2275, 2280, 2286, 2288, 2290, 2292, 2292, 2301, 2308, 2316, 2320, 2330, 2337, 2345, 2353, 2362, 2370, 2377, 2384, 2391, 2390, 2391, 2394, 2396, 2403, 2409, 2416, 2423, 2431, 2437, 2447, 2456, 2465, 2473, 2477, 2483, 2485, 2487, 2489, 2489, 2498, 2505, 2513, 2518, 2528, 2535, 2542, 2550, 2559, 2567, 2574, 2581, 2588, 2587, 2588, 2591, 2593, 2600, 2606, 2613, 2620, 2628, 2634, 2644, 2653, 2662, 2670, 2674, 2680, 2682, 2684, 2686, 2686, 2695, 2702, 2710, 2715, 2725, 2732, 2739, 2747, 2756, 2764, 2771, 2778, 2785, 2784, 2785, 2788, 2790, 2797, 2804, 2811, 2818, 2826, 2832, 2842, 2851, 2861, 2869, 2874, 2880, 2882, 2884, 2886, 2886, 2895, 2902, 2910, 2915, 2925, 2933, 2940, 2949, 2958, 2966, 2973, 2981, 2988, 2987, 2988, 2991, 2993, 3000, 3008, 3017, 3026, 3034, 3044, 3049, 3056, 3062, 3070, 3068, 3070, 3073, 3074, 3082, 3085, 3093, 3100, 3109, 3108, 3111, 3113, 3116, 3120, 3127, 3134, 3142, 3150, 3157, 3166, 3175, 3184, 3192, 3196, 3205, 3214, 3223, 3231, 3241, 3247, 3254, 3261, 3269, 3267, 3269, 3272, 3273, 3281, 3284, 3292, 3300, 3309, 3308, 3311, 3313, 3316, 3320, 3327, 3335, 3343, 3352, 3359, 3369, 3378, 3387, 3395, 3399, 3408, 3417, 3426, 3434, 3444, 3449, 3456, 3463, 3471, 3469, 3471, 3474, 3475, 3483, 3487, 3495, 3503, 3512, 3511, 3514, 3516, 3519, 3523, 3530, 3538, 3545, 3554, 3561, 3571, 3580, 3589, 3597, 3601, 3610, 3619, 3628, 3636, 3646, 3652, 3659, 3666, 3674, 3672, 3674, 3677, 3678, 3686, 3689, 3697, 3705, 3714, 3713, 3716, 3718, 3721, 3725, 3732, 3740, 3748, 3757, 3764, 3774, 3783, 3792, 3800, 3804, 3812, 3821, 3830, 3838, 3848, 3853, 3860, 3866, 3874, 3872, 3874, 3877, 3878, 3886, 3889, 3897, 3904, 3913, 3912, 3915, 3917, 3920, 3924, 3931, 3938, 3946, 3954, 3961, 3970, 3979, 3988, 3996, 4000 };
            for (int i = 0; i < expectedValue.Count; i++)
            {
                Debug.Assert(expectedValue[i] == newSteps[i]);
            }

            //testSteps = new int[] { 116, 107, 127, 125, 185 };
            testSteps = new int[] { 185, 125, 127, 107, 116 };

            newSteps = StepMaker.MakeSteps(testSteps, new ZeroNoise());
            expectedValue = new List<int> { 185, 182, 180, 177, 175, 173, 170, 168, 165, 163, 161, 158, 156, 153, 151, 149, 146, 144, 141, 139, 137, 134, 132, 129, 127, 125, 127, 123, 119, 115, 111, 107, 116 };
            for (int i = 0; i < newSteps.Count; i++)
            {
                Debug.Assert(expectedValue[i] == newSteps[i]);
                // Console.Write($"{newSteps[i]} ");
            }
            
        }
    }
}