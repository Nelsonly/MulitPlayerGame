using UnityGameFramework.Runtime;

namespace StarForce
{
    public class DRStyleResource : DataRowBase
    {
        // 定义数据表中的所有字段
        public int StyleId { get; private set; }
        public override int Id { get; }
        public string StyleName { get; private set; }
        public string Block { get; private set; }
        public string Chessboard { get; private set; }
        public string PlaceTip { get; private set; }
        public string TipNewBase { get; private set; }
        public string TipUnbelievable { get; private set; }
        public string TipCompliment { get; private set; }
        public string ComboEffect { get; private set; }
        public string TopUI { get; private set; }
        public string BottomUI { get; private set; }
        public string Background { get; private set; }
        public string PlaceTipBlock { get; private set; }
        public string ChessBlock { get; private set; }
        public string ScoreTip { get; private set; }
        // 实现解析数据行的方法
        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);
            for (int i = 0; i < columnStrings.Length; i++)
            {
                columnStrings[i] = columnStrings[i].Trim(DataTableExtension.DataTrimSeparators);
            }
            int index = 0;
            StyleId = int.Parse(columnStrings[index++]);
            StyleName = columnStrings[index++];
            Block = columnStrings[index++];
            Chessboard = columnStrings[index++];
            PlaceTip = columnStrings[index++];
            TipNewBase = columnStrings[index++];
            TipUnbelievable = columnStrings[index++];
            TipCompliment = columnStrings[index++];
            ComboEffect = columnStrings[index++];
            TopUI = columnStrings[index++];
            BottomUI = columnStrings[index++];
            Background = columnStrings[index++];
            PlaceTipBlock = columnStrings[index++];
            ChessBlock = columnStrings[index++];
            ScoreTip = columnStrings[index++];
            return true;
        }
    }
}