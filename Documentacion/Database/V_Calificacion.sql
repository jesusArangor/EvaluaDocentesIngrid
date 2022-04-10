create view V_Calificacion As(
select c.id_calificacion ,
c.cal_nota nota_calificada,
c.cal_observacion observacion_calificacion,
c.cal_plan_mejora plan_mejora,
c.cal_usu_ing id_usuario_ingresa,
c.cal_usu_mod id_usuario_modifica,
c.for_id id_Formulario,
f.for_fase Fase_formato,
f.for_calif_fase Fase_califica_formato,
f.for_item item_formato,
f.for_descripcion descripcion_formato,
f.for_puntaje_max puntaje_max_formato,
c.eva_id id_Evalucion ,
e.cur_id ,
cu.cur_nombre Nombre_Curso,
e.sed_id ,
s.sed_nombre Nombre_Sede,
e.fac_id ,
fa.fac_nombre Nombre_Facultad,
e.prog_id ,
p.prog_nombre Nombre_Programa,
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
from calificacion c 
inner join formato f on f.for_id =c.for_id 
inner join evaluacion e on e.eva_id =c.eva_id 
inner join curso cu on cu.cur_id =e.cur_id 
inner join sede s on s.sed_id =e.sed_id 
inner join facultad fa on fa.fac_id =e.fac_id 
inner join programa p on p.prog_id =e.prog_id 
inner join docente d on d.doc_id =e.eva_doc_id 
inner join usuario u on u.usu_id =e.eva_usu_mod_id 
inner join usuario u2 on u2.usu_id =e.eva_usu_ing_id 
inner join carga_evaluacion ce on ce.care_id =e.eva_care_id 
);