using System.Collections.Generic;

namespace SimpleApp.Models
{
    public enum Color
    {
        Red, Green, Yellow, Purple
    }

    public class Votes
    {
        private static Dictionary<Color, int> _votes = new Dictionary<Color, int>();

        /// <summary>
        /// 新增投票
        /// </summary>
        /// <param name="color"></param>
        public static void RecordVote(Color color)
        {
            _votes[color] = _votes.ContainsKey(color) ? _votes[color] + 1 : 1;
        }

        /// <summary>
        /// 更新投票数
        /// </summary>
        /// <param name="newColor"></param>
        /// <param name="oldColor"></param>
        public static void ChangeVote(Color newColor, Color oldColor)
        {
            if (_votes.ContainsKey(oldColor))
            {
                _votes[oldColor]--;
            }
            RecordVote(newColor);
        }

        /// <summary>
        /// 获取指定颜色的数量
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static int GetVotes(Color color)
        {
            return _votes.ContainsKey(color) ? _votes[color] : 0;
        }
    }
}