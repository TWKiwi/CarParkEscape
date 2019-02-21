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
        public bool CarMoving;
        private List<string> _output = new List<string> { };

        public string[] escape(int[,] carPark)
        {
            _parkSize = carPark.GetLength(1);
            var parkingData = ArrayProcessor(carPark);
            var enumerator = parkingData.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (ShouldGoDown(enumerator.Current))
                {
                    _carPosition = UpdateCarPosition(enumerator);
                    var staircasePosition = GetStaircasePosition(enumerator);
                    GoStaircase(_output, staircasePosition);
                    GoDown(_output);
                    _carPosition = staircasePosition;
                }
                else if (AtGroundFloor(enumerator.Current))
                {
                    _carPosition = UpdateCarPosition(enumerator);
                    GoEscape(_output, _carPosition);
                }
            }
            return _output.ToArray();
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
                output[output.Count- 1] = "D" + i;
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

        private int UpdateCarPosition(List<string[]>.Enumerator enumerator)
        {
            CarMoving = true;
            return Array.FindIndex(enumerator.Current, x => x == _car) == -1
                ? _carPosition
                : Array.FindIndex(enumerator.Current, x => x == _car);
        }

        private string TurnRightOrLeft(int i)
        {
            return i > 0 ? "L" : "R";
        }

        private List<string[]> ArrayProcessor(int[,] carPark)
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

        private bool AtGroundFloor(string[] data)
        {
            return !data.Contains(_staircase);
        }

        private bool ShouldGoDown(string[] data)
        {
            return data.Contains(_staircase) &&
                   (data.Contains(_car) || CarMoving);
        }
    }
}