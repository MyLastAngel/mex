# Ozon и новая база данных

Ozon решил придумать новую систему хранения информации пользователей, в данной базе каждому пользователю будет сопоставлен его номер - id (целое неотрицательное число). Так как Ozon — крупная компания, то постоянно регистрируются новые пользователи, для выделения id нового пользователя берется минимальное неотрицательное число, которого еще нет в множестве (боле формально берется Mex набора чисел), например, mex([4, 33, 0, 1, 1, 5]) = 2, а mex([1, 2, 3]) = 0.

К сожалению, любая база должна быть защищена от злоумышленников, для этого иногда базу перестраивают — выбирается какое-то число x и для каждого пользователя его id заменяется на idLx (операци побитового сложения по модулю 2), надо реализовать такую структуру, возвращающую Mex множества и выполняющую операцию шифрования для заданого x.

# Формат входных данных
Считайте, что данные подаются в любом удобном вам виде, вам требуется просто реализовать
структуру, выполняющая два вида запросов:

1) Зарегистрировать нового пользователя.
2) Зашифровать все текущие данные с помощью нового ключа x.


# Для примера разберем следующий случай :

Пусть изначально у нас есть 2 пользователя с id = 1 и 3, пусть сначала мы решили зашифровать нашу базу с помощью числа 1, затем создать нового пользователя, тогда его номер будет 1, так как база будет состоять из номеров 0 и 2, допустим теперь текущую базу требуется зашифровать еще раз с помощью снова ключа 1, тогда текущая база состоит из чисел 0, 1, 2 и она станет 0, 1, 3, теперь при регистрации нового пользователя нам нужно будет выдать ему номер 2.

# Формат выходных данных

Для каждого нового пользователя вывести его id.

# Замечание

От вас требуется придумать наиболее оптимальное решение для задачи с точки зрения асимптотики.
