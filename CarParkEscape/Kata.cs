using System;
using System.Collections;
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

        public string[] Escape(int[,] carPark)
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
                    _carPosition = Array.FindIndex(enumerator.Current, x => x == _car);
                    var staircasePosition = Array.FindIndex(enumerator.Current, x => x == _staircase);
                    output.Add($"{TurnRightOrLeft(_carPosition - staircasePosition)}{Math.Abs(_carPosition - staircasePosition)}");
                    output.Add($"D1");
                    _carPosition = staircasePosition;
                }
                else if (NeedGoOut(enumerator.Current))
                {
                    //出去
                    var position = Array.FindIndex(enumerator.Current, x => x == _car);
                    position = position == -1 ? _carPosition : position;
                    output.Add($"R{_parkSize - position - 1}");
                }
                // 車不在那層沒有必要做判斷
            }
            return output.ToArray();
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
                   data.Contains(_car);
        }
    }
}