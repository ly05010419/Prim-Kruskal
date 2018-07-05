# 通过Prim或者Kruskal获得MST(最小生成树)

# Prim 
> 总是两集合之间的寻找最小边得到最小生成树。

> 1. 已访问集合V{a,b,c} 未访问集合W{c,d,e}
> 2. 寻找V和W之间的最小边Kante， 把Kante.EndNode加入已访问集合V. 

> 原理如下
> https://github.com/ly05010419/Prim-Kruskal/blob/master/Algorithmus%20von%20Prim.pdf


具体实现没有使用到边，相反通过利用PriorityQueue和Knoten，点继承了边的权重，实现Krim算法：
> 1. StartKnoten得到所有子Knoten，更新子Knoten的Gewicht为Kante.gewicht.
> 2. 通过PriorityQueue获得最小的Knote，作为新的StartNode，继续下去。

# Kruskal
> 通过插入最小的变，注意不能形成圈，得到最小生成树。

> 按从小到大排序所有边
> 依次加入最小边
> 检查有无圈存在
> 加入所有边后就是最小生成树

TUM算法详解
http://www-m9.ma.tum.de/Allgemeines/GraphAlgorithmenEn
