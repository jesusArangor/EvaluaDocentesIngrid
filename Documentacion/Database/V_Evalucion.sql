create view V_Evalucion as (
select e.eva_id  id_evalucion, 
e.cur_id , c.cur_nombre Nombre_Curso,
e.sed_id , s.sed_nombre Nombre_Sede,
e.fac_id , f.fac_nombre Nombre_Facultad,
e.prog_id , p.prog_nombre Nombre_Programa,
e.eva_doc_id ,
d.doc_nombre Nombre_Docente,
d.doc_documento Docu_Docente,
d.doc_correo Correo_Docente,
d.doc_telefono Tel_Docente,
e.eva_care_id ,
e.eva_modulo ,
e.eva_curriculo ,
e.eva_plan_aula ,
e.eva_fecing ,
e.eva_fecmod ,
e.eva_usu_mod_id ,
u.usu_nombre Nombre_usu_modifica,
e.eva_usu_ing_id ,
u2.usu_nombre Nombre_Usu_Ingresa,
e.eva_estado,
ce.care_nomarchivo Nombre_Archivo_Carga,
ce.care_semestre Semestre_carga,
ce.care_ano Anio_carga,
ce.care_observacion Observaciones_Carga
from evaluacion e
inner join curso c on c.cur_id =e.cur_id 
inner join sede s on s.sed_id =e.sed_id 
inner join facultad f on f.fac_id =e.fac_id 
inner join programa p on p.prog_id =e.prog_id 
inner join docente d on d.doc_id =e.eva_doc_id 
inner join usuario u on u.usu_id =e.eva_usu_mod_id 
inner join usuario u2 on u2.usu_id =e.eva_usu_ing_id 
inner join carga_evaluacion ce on ce.care_id =e.eva_care_id 
);
