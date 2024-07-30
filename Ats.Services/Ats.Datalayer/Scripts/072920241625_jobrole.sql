-- Create job role table
  create table if not exists public.job_roles (
      id uuid not null,
      sequence_no int not null,
      job_name text not null,
      client_shortcodes text not null,
      hiring_manager text not null,
      sales_manager text not null,
      hiring_type text not null,
      job_description text not null,
      role_level text not null,
      min_salary int not null,
      max_salary int not null,
      job_location text not null,
      shift_sched text not null,
      job_status text not null,
      open_date date not null default current_date,
      closed_date date not null,
      days_covered int not null,  -- Using int to store the number of days
      aging text not null default '0 days & 0 months',  -- Default value for aging
   
    constraint pk_job_roles primary key (id)
  );

-- Create the trigger function
create or replace function update_days_covered()
returns trigger as $$
declare
    days_diff int;
    months_diff int;
    total_days int;
    remaining_days int;
begin
    total_days := new.closed_date - new.open_date;
    months_diff := total_days / 31;  -- Approximate number of months
    remaining_days := total_days % 31;  -- Remaining days after converting to months
    new.days_covered := total_days;
    new.aging := months_diff || ' months & ' || remaining_days || ' days';


    return new;
end;
$$ language plpgsql;

-- Create the trigger
create trigger trg_update_days_covered
before insert or update on public.job_roles
for each row
execute procedure update_days_covered();