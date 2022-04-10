create view V_docente As(
select 
d.doc_id ,
d.doc_documento ,
d.doc_nombre ,
d.doc_correo ,
d.doc_telefono ,
d.doc_fecing ,
d.doc_fecmod ,
d.doc_usu_ing_id ,
u.usu_nombre Nombre_usu_ingresa,
d.doc_usu_mod_id ,
u2.usu_nombre Nombre_us_modifica,
d.doc_idcarga,
cd.card_fecha Fecha_carga,
cd.card_usu_id Usuario_carga,
cd.card_completo completo_carga,
cd.card_observacion Observacion_carga,
cd.card_errores Errores_carga
from docente d 
inner join carga_docente cd on cd.card_id =d.doc_idcarga 
inner join usuario u on u.usu_id =d.doc_usu_ing_id 
inner join usuario u2 on u2.usu_id =d.doc_usu_mod_id 
);