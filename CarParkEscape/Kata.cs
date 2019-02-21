using System;
using System.Collections.Generic;
using System.Linq;

namespace CarParkEscape
{
    public class Kata
    {
        private string _car = "2";
        private string _staircase = "1";
        private int _parkSize;
        private int _carPosition;
        public bool _carMoving = false;

        public string[] escape(int[,] carPark)
        {
            _parkSize = carPark.GetLength(1);
            var output = new List<string> { };
            var parkingData = arrayProcesser(carPark);
            var enumerator = parkingData.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (NeedGoDown(enumerator.Current))
                {
                    // 2樓以上
                    _carPosition = GetCarPosition(enumerator);
                    var staircasePosition = GetStaircasePosition(enumerator);
                    GoStaircase(output, staircasePosition);
                    GoDown(output);
                    _carPosition = staircasePosition;
                    _carMoving = true;
                }
                else if (NeedGoOut(enumerator.Current))
                {
                    //出去
                    var position = GetCarPosition(enumerator);
                    GoEscape(output, position);
                }
                // 車不在那層沒有必要做判斷
            }
            return output.ToArray();
        }

        private void GoEscape(List<string> output, int position)
        {
            var move = _parkSize - position - 1;
            if (move != 0)
            {
                output.Add($"R{move}");
            }
        }

        private static void GoDown(List<string> output)
        {
            if (output.Last().StartsWith("D"))
            {
                var i = int.Parse(output.Last()[output.Last().Length - 1].ToString());
                ++i;
                output[output.Last().Length - 1] = "D" + i;
            }
            else
            {
                output.Add($"D1");
            }
        }

        private void GoStaircase(List<string> output, int staircasePosition)
        {
            var move = Math.Abs(_carPosition - staircasePosition);
            if (move != 0)
            {
                output.Add($"{TurnRightOrLeft(_carPosition - staircasePosition)}{move}");
            }
        }

        private int GetStaircasePosition(List<string[]>.Enumerator enumerator)
        {
            return Array.FindIndex(enumerator.Current, x => x == _staircase);
        }

        private int GetCarPosition(List<string[]>.Enumerator enumerator)
        {
            return Array.FindIndex(enumerator.Current, x => x == _car) == -1
                ? _carPosition
                : Array.FindIndex(enumerator.Current, x => x == _car);
        }

        private string TurnRightOrLeft(int i)
        {
            return i > 0 ? "L" : "R";
        }

        private List<string[]> arrayProcesser(int[,] carPark)
        {
            var parkingData = new List<string[]>();
            var tempFloorData = new string[_parkSize];
            var count = 0;
            var enumerator = carPark.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (count >= _parkSize)
                {
                    count = 0;
                    parkingData.Add(tempFloorData);
                    tempFloorData = new string[_parkSize];
                }

                tempFloorData[count] = enumerator.Current.ToString();
                count++;
            }
            parkingData.Add(tempFloorData);
            return parkingData;
        }

        private bool NeedGoOut(string[] data)
        {
            return !data.Contains(_staircase);
        }

        private bool NeedGoDown(string[] data)
        {
            return data.Contains(_staircase) &&
                   (data.Contains(_car) || _carMoving);
        }
    }
}