﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using try5000rpg.DTOs.Fights;
using try5000rpg.Models;

namespace try5000rpg.Services.FightService
{
    public interface IFightService
    {
        Task<ServiceResponse<AttackResultsDTO>> WeaponAttack(WeaponAttackDTO reqest);
        Task<ServiceResponse<AttackResultsDTO>> SkillAttack(SkillAttackDTO reqest);
        Task<ServiceResponse<FightResultDTO>> Fight(FightRequestDTO reqest);

        Task<ServiceResponse<List<HighScoreDTO>>> GetHighScore();
    }
}
