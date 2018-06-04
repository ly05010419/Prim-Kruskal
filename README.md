# 通过Prim或者Kruskal获得MST(最小生成树)

# Prim
> 1. 已访问节点V{node0} 未访问节点W{node1，node2，…}
> 2. 找到连接V和W的最小边k， k.endNode加入V.

> 原理如下
> https://github.com/ly05010419/Prim-Kruskal/blob/master/Algorithmus%20von%20Prim.pdf


实现：
> 1. StartNode更新所有子Node，Gewicht为k.gewicht.
> 2. 找到最小子node，作为新的StartNode

# Kruskal
> 按从小到大排序所有边
> 依次加入最小边
> 检查有无圈存在
> 加入所有边后就是最小生成树
