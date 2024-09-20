using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

namespace txt2ev
{
    public static class eventParser
    {
        public static eventClass[] parseEvent(TextAsset inputAsset)
        {
            string inputPath = inputAsset.name;
            string input = inputAsset.ToString();
            string[] lines = input.Split('\n');
            string[][] words = lines.Select(x => x.Split(' ')).ToArray();
            List<eventClass> result = new List<eventClass>();
            for (int i = 0; i < lines.Length; i++)
            {
                string[] currentLine = words[i];
                string actorSymbol = currentLine[0];

                if (actorSymbol.Contains("{"))
                {
                    Debug.Log("Block detected in line " + i);
                    int currentIndex = i + 1;
                    while (!words[currentIndex][0].Contains("}"))
                    {
                        if (words[currentIndex][0].Contains("{"))
                        {
                            currentIndex = ignoreOtherStep(words, currentIndex + 1);
                        }
                        currentIndex++;
                    }
                    string blockInput = string.Join(
                            "\n",
                            lines.Skip(i + 1).Take(currentIndex - i - 1)
                        )
                        .Replace("\t", "");
                    Debug.Log(blockInput);
                    string[] actorArgs = new string[currentLine.Length - 1];
                    for (int j = 1; j < currentLine.Length; j++)
                    {
                        actorArgs[j - 1] = currentLine[j].Replace("\"", "");
                    }
                    result.Add(
                        new eventClass(
                            inputPath,
                            actorArgs,
                            parseEvent(new TextAsset(blockInput)),
                            i
                        )
                    );
                    i = currentIndex;
                }
                else
                {
                    string[] actorArgs = new string[currentLine.Length - 1];
                    for (int j = 1; j < currentLine.Length; j++)
                    {
                        actorArgs[j - 1] = currentLine[j].Replace("\"", "");
                    }

                    eventActor actor = eventActorFactory.str2EA(actorSymbol);

                    if (actor == null)
                    {
                        Debug.LogError(
                            $"Actor not found: \"{actorSymbol}\"\nIn line {i + 1} of {inputPath}"
                        );
                        continue;
                    }
                    else
                    {
                        result.Add(new eventClass(inputPath, actor, actorArgs, i));
                    }
                }
            }

            return result.ToArray();
        }

        public static int ignoreOtherStep(string[][] words, int currentIndex)
        {
            while (!words[currentIndex][0].Contains("}"))
            {
                if (words[currentIndex][0].Contains("{"))
                {
                    currentIndex = ignoreOtherStep(words, currentIndex + 1);
                }
                currentIndex++;
            }
            return currentIndex;
        }
    }
}
