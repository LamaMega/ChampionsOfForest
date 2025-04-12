using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChampionsOfForest.Player
{
	public interface IAdditiveStat<T>
	{
		T Add(T amount);
		T Substract(T amount);
	}
	public interface IMultiplicativeStat<T>
	{
		T Multiply(T amount);
		T Divide(T amount);
	}
}
