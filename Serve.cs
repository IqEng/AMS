using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace AMS
{
    public class Serve
    {
        public DataTable campaignPerformanceReport(string spname, string FromDate, string ToDate, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = ToDate;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    DataTable dtx = new DataTable();
                    return dtx;
                }
            }
            catch
            {
                DataTable dtx = new DataTable();
                return dtx;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable bannerPerformanceReport(string spname, string FromDate, string ToDate, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = ToDate;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    DataTable dtx = new DataTable();
                    return dtx;
                }
            }
            catch
            {
                DataTable dtx = new DataTable();
                return dtx;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable websitePerformanceReport(string spname, string FromDate, string ToDate, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = ToDate;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    DataTable dtx = new DataTable();
                    return dtx;
                }
            }
            catch
            {
                DataTable dtx = new DataTable();
                return dtx;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable zonePerformanceReport(string spname, string FromDate, string ToDate, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = ToDate;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    DataTable dtx = new DataTable();
                    return dtx;
                }
            }
            catch
            {
                DataTable dtx = new DataTable();
                return dtx;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable customReport(string spname, int AdvertiserId, int CampaignId, int WebsiteId, string StartDate, string EndDate, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AdvertiserId", SqlDbType.Int).Value = AdvertiserId;
                cmd.Parameters.Add("@CampaignId", SqlDbType.Int).Value = CampaignId;
                cmd.Parameters.Add("@WebsiteId", SqlDbType.Int).Value = WebsiteId;
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = StartDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = EndDate;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    DataTable dtx = new DataTable();
                    return dtx;
                }
            }
            catch
            {
                DataTable dtx = new DataTable();
                return dtx;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable getDetailsByZoneId(string spname, int ZoneId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ZoneId", SqlDbType.Int).Value = ZoneId;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    DataTable dtx = new DataTable();
                    return dtx;
                }
            }
            catch
            {
                DataTable dtx = new DataTable();
                return dtx;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable getWebsiteByCampaignId(string spname, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CampaignId", SqlDbType.Int).Value = UserId;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    DataTable dtx = new DataTable();
                    return dtx;
                }
            }
            catch
            {
                DataTable dtx = new DataTable();
                return dtx;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable getZonesById(string spname, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@WebsiteId", SqlDbType.Int).Value = UserId;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    DataTable dtx = new DataTable();
                    return dtx;
                }
            }
            catch
            {
                DataTable dtx = new DataTable();
                return dtx;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable getBannerListById(string spname, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    DataTable dtx = new DataTable();
                    return dtx;
                }
            }
            catch
            {
                DataTable dtx = new DataTable();
                return dtx;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable getCampaignById(string spname, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    DataTable dtx = new DataTable();
                    return dtx;
                }
            }
            catch
            {
                DataTable dtx = new DataTable();
                return dtx;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable getCampaignByCampaignId(string spname, int CampaignId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CampaignId", SqlDbType.Int).Value = CampaignId;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    DataTable dtx = new DataTable();
                    return dtx;
                }
            }
            catch
            {
                DataTable dtx = new DataTable();
                return dtx;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable getCampaignListById(string spname, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    DataTable dtx = new DataTable();
                    return dtx;
                }
            }
            catch
            {
                DataTable dtx = new DataTable();
                return dtx;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable getWebsiteListById(string spname, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    DataTable dtx = new DataTable();
                    return dtx;
                }
            }
            catch
            {
                DataTable dtx = new DataTable();
                return dtx;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable getUserDetails(string spname, string email, string password)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    DataTable dtx = new DataTable();
                    return dtx;
                }
            }
            catch
            {
                DataTable dtx = new DataTable();
                return dtx;
            }
            finally
            {
                con.Close();
            }
        }
        public string insertClickCount(string spname, int BannerId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlTransaction trn = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand(spname, con, trn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@BannerId", SqlDbType.Int).Value = BannerId;

                try
                {
                    int cunt = cmd.ExecuteNonQuery();
                    if (cunt > 0)
                    {
                        trn.Commit();
                        return "Clickcount has been updated successfully";
                    }
                    else
                    {
                        trn.Rollback();
                        return "Clickcount update process unsuccessful";
                    }
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    return ex.Message + " - " + "Clickcount update process unsuccessful";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " - " + "Clickcount update process unsuccessful";
            }
            finally
            {
                con.Close();
            }
        }
        public string updateBannerById(string spname, int websiteID, int status, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlTransaction trn = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand(spname, con, trn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@BannerId", SqlDbType.Int).Value = websiteID;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = status;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                try
                {
                    int cunt = cmd.ExecuteNonQuery();
                    if (cunt > 0)
                    {
                        trn.Commit();
                        return "Banner has been updated successfully";
                    }
                    else
                    {
                        trn.Rollback();
                        return "Banner update process unsuccessful";
                    }
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    return ex.Message + " - " + "Banner update process unsuccessful";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " - " + "Banner update process unsuccessful";
            }
            finally
            {
                con.Close();
            }
        }
        public string updateWebsiteById(string spname, int websiteID, int status, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlTransaction trn = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand(spname, con, trn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@WebsiteId", SqlDbType.Int).Value = websiteID;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = status;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                try
                {
                    int cunt = cmd.ExecuteNonQuery();
                    if (cunt > 0)
                    {
                        trn.Commit();
                        return "Website has been updated successfully";
                    }
                    else
                    {
                        trn.Rollback();
                        return "Website update process unsuccessful";
                    }
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    return ex.Message + " - " + "Website update process unsuccessful";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " - " + "Website update process unsuccessful";
            }
            finally
            {
                con.Close();
            }
        }
        public string insertBanner(string spname, string filenme, int WebsiteId, string BannerSize, int CampaignDDLVlu, int ZoneId, string BannerTypeId, string Target, string txtBannerLinkVlu, string txtBannerNameVlu, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlTransaction trn = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand("insertBanner", con, trn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Name", SqlDbType.Char).Value = txtBannerNameVlu.Trim();
                cmd.Parameters.Add("@WebsiteId", SqlDbType.Int).Value = WebsiteId;
                cmd.Parameters.Add("@FileName", SqlDbType.Char).Value = filenme;
                cmd.Parameters.Add("@CampaignId", SqlDbType.Int).Value = CampaignDDLVlu;
                cmd.Parameters.Add("@BannerSizeId", SqlDbType.Char).Value = BannerSize;
                cmd.Parameters.Add("@ZoneId", SqlDbType.Int).Value = ZoneId;
                cmd.Parameters.Add("@BannerTypeId", SqlDbType.Char).Value = BannerTypeId.Trim();
                cmd.Parameters.Add("@Target", SqlDbType.Char).Value = Target.Trim();
                cmd.Parameters.Add("@BannerLink", SqlDbType.Char).Value = txtBannerLinkVlu.Trim();
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                try
                {
                    int cunt = cmd.ExecuteNonQuery();
                    if (cunt > 0)
                    {
                        trn.Commit();
                        return "Banner has been created successfully.";
                    }
                    else
                    {
                        trn.Rollback();
                        return "Banner creation process unsuccessful.";
                    }
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    return ex.Message + " - " + "Operation unsuccessful.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " - " + "Banner creation process unsuccessful.";
            }
            finally
            {
                con.Close();
            }
        }
        public string insertWebsite(string spname, string Name, string WebsiteUrl, decimal budget, string TargetFrame, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlTransaction trn = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand("insertWebsite", con, trn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Name", SqlDbType.Char).Value = Name.Trim();
                cmd.Parameters.Add("@WebsiteUrl", SqlDbType.VarChar).Value = WebsiteUrl.Trim();
                cmd.Parameters.Add("@Budget", SqlDbType.Decimal).Value = budget;
                cmd.Parameters.Add("@TargetFrame", SqlDbType.Int).Value = TargetFrame;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                try
                {
                    int cunt = cmd.ExecuteNonQuery();
                    if (cunt > 0)
                    {
                        trn.Commit();
                        return "Website has been created successfully.";
                    }
                    else
                    {
                        trn.Rollback();
                        return "Website creation process unsuccessful.";
                    }
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    if (ex.Message.Contains("PRIMARY KEY"))
                    {
                        return "Website already exists.";
                    }
                    else
                    {
                        return ex.Message + " - " + "Operation unsuccessful.";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " - " + "Website creation process unsuccessful.";
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable getWebsiteByAdvertiserId(string spname, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AdvertiserId", SqlDbType.Int).Value = UserId;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    DataTable dtx = new DataTable();
                    return dtx;
                }
            }
            catch
            {
                DataTable dtx = new DataTable();
                return dtx;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable getZoneListById(string spname, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    DataTable dtx = new DataTable();
                    return dtx;
                }
            }
            catch
            {
                DataTable dtx = new DataTable();
                return dtx;
            }
            finally
            {
                con.Close();
            }
        }
        public string deleteUserById(string spname, string Email, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlTransaction trn = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand("deleteUserById", con, trn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                try
                {
                    int cunt = cmd.ExecuteNonQuery();
                    if (cunt > 0)
                    {
                        trn.Commit();
                        return "Account has been deleted successfully";
                    }
                    else
                    {
                        trn.Rollback();
                        return "Account deletion process unsuccessful";
                    }
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    return ex.Message + " - " + "Account deletion process unsuccessful";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " - " + "Account deletion process unsuccessful";
            }
            finally
            {
                con.Close();
            }
        }
        public string updatePasswordProfileById(string spname, string OldPassword, string NewPassword, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlTransaction trn = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand("updatePasswordProfileById", con, trn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@OldPassword", SqlDbType.NVarChar).Value = OldPassword;
                cmd.Parameters.Add("@NewPassword", SqlDbType.NVarChar).Value = NewPassword;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                try
                {
                    int cunt = cmd.ExecuteNonQuery();
                    if (cunt > 0)
                    {
                        trn.Commit();
                        return "Password has been updated successfully";
                    }
                    else
                    {
                        trn.Rollback();
                        return "Password update process unsuccessful";
                    }
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    return ex.Message + " - " + "Password update process unsuccessful";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " - " + "Password update process unsuccessful";
            }
            finally
            {
                con.Close();
            }
        }
        public string updateProfileImageById(string spname, string Pic, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlTransaction trn = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand("updateProfileImageById", con, trn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Pic", SqlDbType.Char).Value = Pic;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                try
                {
                    int cunt = cmd.ExecuteNonQuery();
                    if (cunt > 0)
                    {
                        trn.Commit();
                        return "Profile image has been updated successfully";
                    }
                    else
                    {
                        trn.Rollback();
                        return "Profile image update process unsuccessful";
                    }
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    return ex.Message + " - " + "Profile image update process unsuccessful";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " - " + "Profile image update process unsuccessful";
            }
            finally
            {
                con.Close();
            }
        }
        public string updateProfileById(string spname, string profileDescription, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlTransaction trn = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand("updateProfileById", con, trn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Description", SqlDbType.Char).Value = profileDescription;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                try
                {
                    int cunt = cmd.ExecuteNonQuery();
                    if (cunt > 0)
                    {
                        trn.Commit();
                        return "Profile has been updated successfully";
                    }
                    else
                    {
                        trn.Rollback();
                        return "Profile update process unsuccessful";
                    }
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    return ex.Message + " - " + "Profile update process unsuccessful";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " - " + "Profile update process unsuccessful";
            }
            finally
            {
                con.Close();
            }
        }
        public string updateUserByActivationCode(string spname, string KeyPara)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlTransaction trn = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand("updateUserByActivationCode", con, trn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@KeyPara", SqlDbType.VarChar).Value = KeyPara;

                try
                {
                    int cunt = cmd.ExecuteNonQuery();
                    if (cunt > 0)
                    {
                        trn.Commit();
                        return "Account has been updated successfully";
                    }
                    else
                    {
                        trn.Rollback();
                        return "Account update process unsuccessful";
                    }
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    return ex.Message + " - " + "Account update process unsuccessful";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " - " + "Account update process unsuccessful";
            }
            finally
            {
                con.Close();
            }
        }
        public string updateZoneById(string spname, int ZoneId, int Status, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlTransaction trn = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand("updateZoneById", con, trn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ZoneId", SqlDbType.Int).Value = ZoneId;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = Status;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                try
                {
                    int cunt = cmd.ExecuteNonQuery();
                    if (cunt > 0)
                    {
                        trn.Commit();
                        return "Zone has been updated successfully";
                    }
                    else
                    {
                        trn.Rollback();
                        return "Zone update process unsuccessful";
                    }
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    return ex.Message + " - " + "Zone update process unsuccessful";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " - " + "Zone update process unsuccessful";
            }
            finally
            {
                con.Close();
            }
        }
        public string insertUser(string spname, string EmailTB_, string PasswordTB_, string DName, string AId, string Phone, string KeyPara, string Address)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlTransaction trn = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand("insertUser", con, trn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = EmailTB_.Trim();
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = PasswordTB_.Trim();
                cmd.Parameters.Add("@DName", SqlDbType.Char).Value = DName.Trim();
                cmd.Parameters.Add("@AId", SqlDbType.Int).Value = AId;
                cmd.Parameters.Add("@Phone", SqlDbType.Char).Value = Phone.Trim();
                cmd.Parameters.Add("@KeyPara", SqlDbType.VarChar).Value = KeyPara.Trim();
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = Address.Trim();

                try
                {
                    int cunt = cmd.ExecuteNonQuery();
                    if (cunt > 0)
                    {
                        //bool res = SendEmail(cls.Password.Trim(), cls.DName.Trim(), cls.Email.Trim());
                        //if (res == true)
                        //{
                        trn.Commit();
                        return "Profile has been created successfully!";
                        //}
                        //else
                        //{
                        //    trn.Rollback();
                        //    return new JsonResult("Profile creation process unsuccessful due to Email sending failure!");
                        //}
                    }
                    else
                    {
                        trn.Rollback();
                        return "Profile creation process unsuccessful.";
                    }
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    if (ex.Message.Contains("PRIMARY KEY"))
                    {
                        return "Profile creation process unsuccessful! Email already exists.";
                    }
                    else
                    {
                        return "Profile creation process unsuccessful.";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " - " + "Profile creation process unsuccessful.";
            }
            finally
            {
                con.Close();
            }
        }
        public string insertZone(string spname, string Name, string Description, string WebsiteId, string ZoneTypeId, string ZoneSizeId, int mWidth, int mHeight, int Id)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlTransaction trn = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand("insertZone", con, trn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Name", SqlDbType.Char).Value = Name.Trim();
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description.Trim();
                cmd.Parameters.Add("@WebsiteId", SqlDbType.Int).Value = WebsiteId;
                cmd.Parameters.Add("@ZoneTypeId", SqlDbType.Char).Value = ZoneTypeId.Trim();
                cmd.Parameters.Add("@ZoneSizeId", SqlDbType.Char).Value = ZoneSizeId.Trim();
                cmd.Parameters.Add("@mWidth", SqlDbType.Int).Value = mWidth;
                cmd.Parameters.Add("@mHeight", SqlDbType.Int).Value = mHeight;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = Id;

                try
                {
                    int cunt = cmd.ExecuteNonQuery();
                    if (cunt > 0)
                    {
                        trn.Commit();
                        return "Zone has been created successfully.";
                    }
                    else
                    {
                        trn.Rollback();
                        return "Zone creation process unsuccessful.";
                    }
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    if (ex.Message.Contains("PRIMARY KEY"))
                    {
                        return "Zone already exists.";
                    }
                    else
                    {
                        return ex.Message + " - " + "Operation unsuccessful.";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " - " + "Operation unsuccessful.";
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable getCredentialsByEmail(string spname, string Email)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Email", SqlDbType.Int).Value = Email;

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    DataTable dtx = new DataTable();
                    return dtx;
                }
            }
            catch
            {
                DataTable dtx = new DataTable();
                return dtx;
            }
            finally
            {
                con.Close();
            }
        }
        public string updateCampaignById(string spname, int CampaignId, int status, int UserId)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlTransaction trn = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand("updateCampaignById", con, trn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CampaignId", SqlDbType.Int).Value = CampaignId;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = status;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                try
                {
                    int cunt = cmd.ExecuteNonQuery();
                    if (cunt > 0)
                    {
                        trn.Commit();
                        return "Campaign has been updated successfully";
                    }
                    else
                    {
                        trn.Rollback();
                        return "Campaign update process unsuccessful";
                    }
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    return ex.Message + " - " + "Campaign update process unsuccessful";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " - " + "Campaign update process unsuccessful";
            }
            finally
            {
                con.Close();
            }
        }
        public string updateCampaign(string spname, int txtCampaignId, int prio, int Id)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlTransaction trn = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand("updateCampaign", con, trn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id", SqlDbType.Char).Value = txtCampaignId;
                cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = prio;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = Id;

                try
                {
                    int cunt = cmd.ExecuteNonQuery();
                    if (cunt > 0)
                    {
                        trn.Commit();
                        return "Campaign has been updated successfully.";
                    }
                    else
                    {
                        trn.Rollback();
                        return "Campaign update process unsuccessful.";
                    }
                }
                catch
                {
                    trn.Rollback();
                    return "Campaign update process unsuccessful.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " - " + "Campaign update process unsuccessful.";
            }
            finally
            {
                con.Close();
            }
        }
        public string insertCampaign(string spname, string txtCampaignName_, string txtCampaignDescription_, int prio, int AdvertiserDDL_,
            string startDate, string endDate, int Id)
        {
            SqlConnection con = new SqlConnection(AuthClass.Getconstring().ToString());
            try
            {
                con.Open();
                SqlTransaction trn = con.BeginTransaction();

                SqlCommand cmd = new SqlCommand("insertCampaign", con, trn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Name", SqlDbType.Char).Value = txtCampaignName_;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = txtCampaignDescription_;
                cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = prio;
                cmd.Parameters.Add("@AdvertiserId", SqlDbType.Int).Value = AdvertiserDDL_;
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = Id;

                try
                {
                    int cunt = cmd.ExecuteNonQuery();
                    if (cunt > 0)
                    {
                        trn.Commit();
                        return "Campaign has been created successfully.";
                    }
                    else
                    {
                        trn.Rollback();
                        return "Campaign creation process unsuccessful.";
                    }
                }
                catch
                {
                    trn.Rollback();
                    return "Campaign creation process unsuccessful.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message + " - " + "Campaign creation process unsuccessful.";
            }
            finally
            {
                con.Close();
            }
        }
    }
}