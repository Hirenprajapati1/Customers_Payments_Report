
select FORMAT(Inv.InvoiceDate, 'MM-yy') Month,
Cust.CustomerName,
Count(Inv.InvoiceAmount) No_of_Invoices,
SUM(Inv.InvoiceAmount) Sales
--Sum(Py.PaymentAmount) Payment_Collection 
from Invoice Inv 
Join Customer Cust on Inv.CustomerNo=Cust.CustomerNo
--join Pyment Py on Inv.InvoiceNo=Py.InvoiceNo
--left join (select sum(Py.PaymentAmount) Payment_Collection,)Py on Py.InvoiceNo=Inv.InvoiceNo
--left join (select Sum(PaymentAmount) Payment_Collection, InvoiceNo from Pyment group by InvoiceNo) Py on Py.InvoiceNo=Inv.InvoiceNo
--outer apply  (select Sum(PaymentAmount) Payment_Collection, InvoiceNo from Pyment   where InvoiceNo=Inv.InvoiceNo 
--group by InvoiceNo)Py
GROUP BY  FORMAT(Inv.InvoiceDate, 'MM-yy'),Cust.CustomerName
Order by FORMAT(Inv.InvoiceDate, 'MM-yy'), Cust.CustomerName;


select FORMAT(Py.PaymentDate, 'MM-yy') Month,
Cust.CustomerName,
Count(Py.PaymentAmount) No_of_Payment,
Sum(Py.PaymentAmount) Payment_Collection 
from Invoice Inv 
Join Customer Cust on Inv.CustomerNo=Cust.CustomerNo
join Pyment Py on Inv.InvoiceNo=Py.InvoiceNo
--left join (select sum(Py.PaymentAmount) Payment_Collection,)Py on Py.InvoiceNo=Inv.InvoiceNo
--left join (select Sum(PaymentAmount) Payment_Collection, InvoiceNo from Pyment group by InvoiceNo) Py on Py.InvoiceNo=Inv.InvoiceNo
--outer apply  (select Sum(PaymentAmount) Payment_Collection, InvoiceNo from Pyment   where InvoiceNo=Inv.InvoiceNo 
--group by InvoiceNo)Py
GROUP BY  FORMAT(Py.PaymentDate, 'MM-yy'),Cust.CustomerName
Order by FORMAT(Py.PaymentDate, 'MM-yy'), Cust.CustomerName;




select FORMAT(Inv.InvoiceDate, 'MM-yy') Month,
Cust.CustomerName,
Count(Inv.InvoiceAmount) No_of_Invoices,
SUM(Inv.InvoiceAmount) Sales,
Sum(Py.PaymentAmount) Payment_Collection 
from Invoice Inv 
Join Customer Cust on Inv.CustomerNo=Cust.CustomerNo
join Pyment Py on Inv.InvoiceNo=Py.InvoiceNo
--left join (select sum(Py.PaymentAmount) Payment_Collection,)Py on Py.InvoiceNo=Inv.InvoiceNo
--left join (select Sum(PaymentAmount) Payment_Collection, InvoiceNo from Pyment group by InvoiceNo) Py on Py.InvoiceNo=Inv.InvoiceNo
--outer apply  (select Sum(PaymentAmount) Payment_Collection, InvoiceNo from Pyment   where InvoiceNo=Inv.InvoiceNo 
--group by InvoiceNo)Py
GROUP BY  FORMAT(Inv.InvoiceDate, 'MM-yy'),Cust.CustomerName
Order by FORMAT(Inv.InvoiceDate, 'MM-yy'), Cust.CustomerName;








Select  Cust.CustomerName,
YEAR(Inv.InvoiceDate) Year,
MONTH(Inv.InvoiceDate) Month,
Count(Inv.InvoiceAmount) No_of_Invoices,
SUM(Inv.InvoiceAmount) Sales
--SUM(Py.PaymentAmount) Pay
From  Invoice Inv Join Customer Cust
on Inv.CustomerNo=Cust.CustomerNo
--join Pyment Py on Py.InvoiceNo=Inv.InvoiceNo

GROUP BY YEAR(Inv.InvoiceDate), MONTH(Inv.InvoiceDate),Cust.CustomerName
Order by YEAR(Inv.InvoiceDate),MONTH(Inv.InvoiceDate), Cust.CustomerName;
;


Select  Cust.CustomerName,
YEAR(Py.PaymentDate) Year,
MONTH(Py.PaymentDate) Month,
Count(Py.PaymentAmount) No_of_Payment,
--SUM(Inv.InvoiceAmount) Sales,
SUM(Py.PaymentAmount) Pay
From  Invoice Inv Join Customer Cust
on Inv.CustomerNo=Cust.CustomerNo
join Pyment Py on Py.InvoiceNo=Inv.InvoiceNo

GROUP BY YEAR(Py.PaymentDate), MONTH(py.PaymentDate),Cust.CustomerName
Order by YEAR(Py.PaymentDate), MONTH(py.PaymentDate), Cust.CustomerName;
;
