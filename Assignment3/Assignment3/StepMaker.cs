using System.Collections.Generic;
using System.Linq;
using System;

namespace Assignment3
{
    public static class StepMaker
    {
        public static List<int> MakeSteps(int[] steps, INoise noise)
        {
            int level = 0;
            List<int> stepsList = steps.ToList();
            int currentStepsCount = stepsList.Count;
            int maxIndex = currentStepsCount;

            for (int i = 0; i < maxIndex - 1; ++i)
            {
                if (stepsList[i + 1] - stepsList[i] > 10 || stepsList[i + 1] - stepsList[i] < -10)
                {
                    AddStepsRecursive(stepsList, noise, level, i);
                }

                int lengthSteps = stepsList.Count;
                i += lengthSteps - currentStepsCount;
                maxIndex += lengthSteps - currentStepsCount;
                currentStepsCount = lengthSteps;
            }
            

            return stepsList;
        }

        public static void AddStepsRecursive(List<int> steps, INoise noise, int level, int index)
        {
            int initialSteps = steps.Count;
            int i;

            int currentNoise;

            if (level == 0)
            {
                int min = steps[index];
                int max = steps[index + 1];

                int firstNum;
                int secondNum;
                int thirdNum;
                int fourthNum;

                currentNoise = noise.GetNext(level);

                if (min * 0.8 + max * 0.2 > 0)
                {
                    firstNum = (int)(min * 0.8 + max * 0.2 + 0.00000001) + currentNoise;
                } 
                else if (min * 0.8 + max * 0.2 < 0)
                {
                    firstNum = (int)(min * 0.8 + max * 0.2 - 0.00000001) + currentNoise;
                }
                else
                {
                    firstNum = (int)(min * 0.8 + max * 0.2) + currentNoise;
                }

                currentNoise = noise.GetNext(level);

                if (min * 0.6 + max * 0.4 > 0)
                {
                    secondNum = (int)(min * 0.6 + max * 0.4 + 0.00000001) + currentNoise;
                }
                else if (min * 0.8 + max * 0.2 < 0)
                {
                    secondNum = (int)(min * 0.6 + max * 0.4 - 0.00000001) + currentNoise;
                }
                else
                {
                    secondNum = (int)(min * 0.6 + max * 0.4) + currentNoise;
                }

                currentNoise = noise.GetNext(level);

                if (min * 0.4 + max * 0.6 > 0)
                {
                    thirdNum = (int)(min * 0.4 + max * 0.6 + 0.00000001) + currentNoise;
                }
                else if (min * 0.8 + max * 0.2 < 0)
                {
                    thirdNum = (int)(min * 0.4 + max * 0.6 - 0.00000001) + currentNoise;
                }
                else
                {
                    thirdNum = (int)(min * 0.4 + max * 0.6) + currentNoise;
                }

                currentNoise = noise.GetNext(level);

                if (min * 0.2 + max * 0.8 > 0)
                {
                    fourthNum = (int)(min * 0.2 + max * 0.8 + 0.00000001) + currentNoise;
                }
                else if (min * 0.8 + max * 0.2 < 0)
                {
                    fourthNum = (int)(min * 0.2 + max * 0.8 - 0.00000001) + currentNoise;
                }
                else
                {
                    fourthNum = (int)(min * 0.2 + max * 0.8) + currentNoise;
                }

                List<int> stepsInserted = new List<int>() { firstNum, secondNum, thirdNum, fourthNum };
                steps.InsertRange(index + 1, stepsInserted);

                AddStepsRecursive(steps, noise, 1, index);
            }

            if (level != 0)
            {
                int iterations = index + 5;
                for (i = index; i < iterations; ++i)
                {
                    if (steps[i + 1] - steps[i] > 10 || steps[i + 1] - steps[i] < -10)
                    {
                        int min = steps[i];
                        int max = steps[i + 1];

                        int firstNum;
                        int secondNum;
                        int thirdNum;
                        int fourthNum;

                        currentNoise = noise.GetNext(level);

                        if (min * 0.8 + max * 0.2 > 0)
                        {
                            firstNum = (int)(min * 0.8 + max * 0.2 + 0.00000001) + currentNoise;
                        }
                        else if (min * 0.8 + max * 0.2 < 0)
                        {
                            firstNum = (int)(min * 0.8 + max * 0.2 - 0.00000001) + currentNoise;
                        }
                        else
                        {
                            firstNum = (int)(min * 0.8 + max * 0.2) + currentNoise;
                        }

                        currentNoise = noise.GetNext(level);

                        if (min * 0.6 + max * 0.4 > 0)
                        {
                            secondNum = (int)(min * 0.6 + max * 0.4 + 0.00000001) + currentNoise;
                        }
                        else if (min * 0.8 + max * 0.2 < 0)
                        {
                            secondNum = (int)(min * 0.6 + max * 0.4 - 0.00000001) + currentNoise;
                        }
                        else
                        {
                            secondNum = (int)(min * 0.6 + max * 0.4) + currentNoise;
                        }

                        currentNoise = noise.GetNext(level);

                        if (min * 0.4 + max * 0.6 > 0)
                        {
                            thirdNum = (int)(min * 0.4 + max * 0.6 + 0.00000001) + currentNoise;
                        }
                        else if (min * 0.8 + max * 0.2 < 0)
                        {
                            thirdNum = (int)(min * 0.4 + max * 0.6 - 0.00000001) + currentNoise;
                        }
                        else
                        {
                            thirdNum = (int)(min * 0.4 + max * 0.6) + currentNoise;
                        }

                        currentNoise = noise.GetNext(level);

                        if (min * 0.2 + max * 0.8 > 0)
                        {
                            fourthNum = (int)(min * 0.2 + max * 0.8 + 0.00000001) + currentNoise;
                        }
                        else if (min * 0.8 + max * 0.2 < 0)
                        {
                            fourthNum = (int)(min * 0.2 + max * 0.8 - 0.00000001) + currentNoise;
                        }
                        else
                        {
                            fourthNum = (int)(min * 0.2 + max * 0.8) + currentNoise;
                        }

                        List<int> stepsInserted = new List<int>() { firstNum, secondNum, thirdNum, fourthNum };
                        steps.InsertRange(i + 1, stepsInserted);

                        AddStepsRecursive(steps, noise, level + 1, i);
                    }

                    int lengthSteps = steps.Count;

                    i += lengthSteps - initialSteps;
                    iterations += lengthSteps - initialSteps;
                    initialSteps = lengthSteps;
                }
            }
        }
    }
}