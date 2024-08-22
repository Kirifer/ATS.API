do $$
begin
  -- alter users table and add audit columns
  alter table if exists public.users add column if not exists created_on timestamp with time zone not null default now();
  alter table if exists public.users add column if not exists creator_id uuid;
  alter table if exists public.users add column if not exists updated_on timestamp with time zone;
  alter table if exists public.users add column if not exists updater_id uuid;
end;
$$