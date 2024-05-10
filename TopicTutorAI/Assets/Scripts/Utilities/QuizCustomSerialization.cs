
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class QuizCustomSerialization
{
    public List<Question> Questions = new List<Question>();

    public static byte[] Serialize(object obj)
    {
        QuizCustomSerialization quizCustomSerialization = (QuizCustomSerialization)obj;

        using (MemoryStream memoryStream = new MemoryStream())
        {
            using (BinaryWriter writer = new BinaryWriter(memoryStream))
            {
                foreach (var question in quizCustomSerialization.Questions)
                {
                    writer.Write(question.Number);
                    writer.Write(question.Text);
                    writer.Write(question.OptionA);
                    writer.Write(question.OptionB);
                    writer.Write(question.OptionC);
                    writer.Write(question.OptionD);
                    writer.Write(question.Answer);
                }
            }

            return memoryStream.ToArray();
        }
    }

    public static object Deserialize(byte[] binaryData)
    {
        QuizCustomSerialization quizCustomSerialization = new();

        using (MemoryStream memoryStream = new MemoryStream(binaryData))
        {
            using (BinaryReader reader = new BinaryReader(memoryStream))
            {
                while (memoryStream.Position < memoryStream.Length)
                {
                    int number = reader.ReadInt32();
                    string text = reader.ReadString();
                    string optionA = reader.ReadString();
                    string optionB = reader.ReadString();
                    string optionC = reader.ReadString();
                    string optionD = reader.ReadString();
                    string answer = reader.ReadString();

                    quizCustomSerialization.Questions.Add(new Question()
                    {
                        Number = number,
                        Text = text,
                        OptionA = optionA,
                        OptionB = optionB,
                        OptionC = optionC,
                        OptionD = optionD,
                        Answer = answer
                    });
                }
            }
        }

        return quizCustomSerialization;
    }
}
