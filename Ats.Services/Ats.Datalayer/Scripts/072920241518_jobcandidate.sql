do $$
begin
  -- Create recruitment table
  create table if not exists public.job_candidates (
    id uuid not null,
    job_role_id text not null,
    job_name text not null,
    candidate_name text not null,
    candidate_cv text not null,
    candidate_email text not null,
    candidate_contact int not null,
    source_tool text not null,
    assigned_hr text not null,
    asking_salary int not null,
    salary_negotiable text not null,
    min_salary int not null,
    max_salary int not null,
    notice_duration text not null,
    application_status text not null,
    final_salary int not null,
    allowance int not null,
    honorarium text not null,
    job_offer text not null,
    candidate_contract text not null,
    remarks text not null,
   
    constraint pk_job_candidates primary key (id)
  );

  create index ix_job_candidates_id
    on public.job_candidates using btree
    (id asc nulls last);
end;
$$