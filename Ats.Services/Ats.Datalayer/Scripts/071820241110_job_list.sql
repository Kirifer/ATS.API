do $$
begin
  -- Create job_lists table (job_lists) table is for testing purposes only. 
  create table if not exists public.job_lists (
    id uuid not null,
    job_title text not null,
    job_description text not null,
    job_location text not null,
    job_setting text not null,
    job_posted timestamp not null,
   
    constraint pk_job_lists primary key (id)
  );

  create index ix_job_lists_id
    on public.job_lists using btree
    (id asc nulls last);
end;
$$