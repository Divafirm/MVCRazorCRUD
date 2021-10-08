delete from alunos where alunoId > 0;
delete from professores where professorId > 0;
DBCC checkident('[alunos]', reseed, 0);
DBCC checkident('[professores]', reseed, 0);
select * from alunos;
select * from professores;