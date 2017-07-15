using System.Windows.Controls;
using System.Windows;
using WinAllYouCan.Code;
using System.Windows.Media;
using System.Windows.Data;
using System.Collections.Generic;

namespace WinAllYouCan.Views
{
	/// <summary>
	/// Interaction logic for ScoreBoardRow.xaml
	/// </summary>
	public partial class ScoreBoardRow : UserControl
	{
		private Style m_RowStyle;
		private Style RowStyle
		{
			get
			{
				if (m_RowStyle == null)
				{
					m_RowStyle = new Style { TargetType = typeof(Border) };
					m_RowStyle.Setters.Add(new Setter { Property = Border.BorderThicknessProperty, Value = "2" });
					m_RowStyle.Setters.Add(new Setter { Property = Border.BorderBrushProperty, Value = "Black" });
				}
				return m_RowStyle;
			}
		}

		public ScoreBoardRow(ScoreBoardRowModel model)
		{
			InitializeComponent();
			model.PropertyChanged += ScoreBoard_PropertyChanged;
			DataContext = model;
		}

		private void ScoreBoard_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if ((sender as ScoreBoardRowModel) != null && e.PropertyName == nameof(ScoreBoardRowModel.Teams))
			{
				BuildHeaderRow((sender as ScoreBoardRowModel).Teams);
			}
			else if ((sender as ScoreBoardRowModel) != null && e.PropertyName == nameof(ScoreBoardRowModel.ScoreBoardValues))
			{
				BuildRow((sender as ScoreBoardRowModel).ScoreBoardValues);
			}
		}

		private void BuildHeaderRow(IEnumerable<Team> teams)
		{
			foreach (Team team in teams)
			{
				//<Border Grid.Row="0" Grid.Column="1" HorizontalAlignment="Stretch" VerticalAlignment="Stretch" Style="{StaticResource ScoreFieldBorder}">
				//	<Viewbox Stretch="Uniform">
				//		<TextBlock Text="{Binding Teams[i].Name}" VerticalAlignment="Center" HorizontalAlignment = "Center" />
				//	</ Viewbox >
				//</ Border >

				TextBlock newBlock = new TextBlock
				{
					VerticalAlignment = VerticalAlignment.Center,
					HorizontalAlignment = HorizontalAlignment.Center
				};
				//make a new source
				BindingOperations.SetBinding(newBlock, TextBlock.TextProperty, new Binding("Name") { Source = team });

				Border cellBorder = new Border
				{
					HorizontalAlignment = HorizontalAlignment.Stretch,
					VerticalAlignment = VerticalAlignment.Stretch,
					Style = RowStyle,
					Child = new Viewbox
					{
						Stretch = Stretch.Uniform,
						Child = newBlock
					}
				};
			}
		}
		private void BuildRow(Code.ScoreBoard scoreBoard)
		{
			for (int i = 0; i < scoreBoard.Scores.Count; i++)
			{
				for (int j =0; j < scoreBoard.Scores[i].Values.Count; i++)
				{
					//<Border Grid.Row="1" Grid.Column="3" HorizontalAlignment="Stretch" VerticalAlignment="Stretch" Style="{StaticResource ScoreFieldBorder}">
					//	<Viewbox Stretch="Uniform">
					//		<TextBlock Text="{Binding ScoreBoardValues.Scores[0].Values[2]}" VerticalAlignment="Center" HorizontalAlignment="Center" />
					//	</Viewbox>
					//</Border>
					TextBlock newBlock = new TextBlock
					{
						VerticalAlignment = VerticalAlignment.Center,
						HorizontalAlignment = HorizontalAlignment.Center
					};
					//make a new source
					BindingOperations.SetBinding(newBlock, TextBlock.TextProperty, new Binding($"Scores[{i}].Values[{j}]") { Source = scoreBoard });

					Border cellBorder = new Border
					{
						HorizontalAlignment = HorizontalAlignment.Stretch,
						VerticalAlignment = VerticalAlignment.Stretch,
						Style = RowStyle,
						Child = new Viewbox
						{
							Stretch = Stretch.Uniform,
							Child = newBlock
						}
					};
				}
			}
		}
	}
}
