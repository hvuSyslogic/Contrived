select mp.Name, mpt.Name, count(1), avg(mpt.DurationMilliseconds)
from MiniProfilers mp
inner join MiniProfilerTimings mpt on mp.Id = mpt.MiniProfilerId
group by mp.Name, mpt.Name
order by avg(mpt.DurationMilliseconds) desc