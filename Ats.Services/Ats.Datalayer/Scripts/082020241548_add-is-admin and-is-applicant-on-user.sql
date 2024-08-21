do $$
begin
  -- alter users table and add column is_admin and is_applicant
  alter table if exists public.users add column if not exists is_admin boolean default false;
  alter table if exists public.users add column if not exists is_applicant boolean default false;
end;
$$