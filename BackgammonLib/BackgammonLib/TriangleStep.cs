using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonLib
{
    public class TriangleStep
    {
        public List<Tool> Tools { get; }
        public PlayerColor.Color Color { private set; get; }
        public bool IsEmpty => Tools.Count == 0 ;
        public int ToolsNum => Tools.Count;
        public int StepPosition { get; }
        

        public TriangleStep(int pos)
        {
            Tools = new List<Tool>();
            Color = pos == 0? PlayerColor.Color.White :  pos == 25? PlayerColor.Color.Black : PlayerColor.Color.Empty;
            StepPosition = pos;
        }

        public void Add(Tool t)
        {
            switch (StepPosition)
            {
                case 0:
                    if (t.Color == PlayerColor.Color.Black)
                        t.Exclude();
                    if (t.Color == PlayerColor.Color.White)
                        Tools.Add(t);
                    break;
                case 25:
                    if (t.Color == PlayerColor.Color.White)
                        t.Exclude();
                    if (t.Color == PlayerColor.Color.Black)
                        Tools.Add(t);
                    break;
                default:
                    if (IsEmpty || Color == t.Color)
                    {
                        Tools.Add(t);
                        Color = t.Color;
                        t.Move(StepPosition);
                        break;
                    }
                    if (ToolsNum == 1)
                    {
                        Tools[0].Eat();
                        Tools.Clear();
                        Tools.Add(t);
                        Color = t.Color;
                        t.Move(StepPosition);
                        break;
                    }
                    throw new MissMatchException("Unable to move tool to destionation step");
            }
        }

        public void Remove(Tool t)
        {
            if (IsEmpty)
                throw new MissMatchException("Unable to Remove Tool, this step is empty");
            Tools.Remove(t);
            if (IsEmpty)
                Color = PlayerColor.Color.Empty;
        }

        public Tool GetTool(Player p)
        {
            Tool temp = Tools.FirstOrDefault(tool => tool.Color == p.Color);
            if (temp == null)
                throw new MissMatchException("You have no tools in that step");
            return temp;
        }

        public bool ContainToolsInColor(PlayerColor.Color c) => Tools.Any(tool => tool.Color == c);

    }
}
